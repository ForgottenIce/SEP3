﻿using System.ComponentModel.DataAnnotations;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace RestAPI.Services;

public class AuthService : IAuthService {
    private readonly ILoginService _loginService;

    public AuthService(ILoginService loginService) {
        _loginService = loginService;
    }

    public async Task<bool> ValidateUser(string username, string password) { //TODO implement proper exceptions
        bool boolean = await _loginService.ValidateUserAsync(new UserLoginDto { Password = password, UserId = username });
        return boolean;
    }

    public Task RegisterUser(User user) { //TODO implement proper exceptions
        if (string.IsNullOrEmpty(user.UserId))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list

        _loginService.RegisterUser(new UserCreationDto { Password = user.Password, UserId = user.UserId });

        return Task.CompletedTask;
    }    
}