using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using gRPC.ServiceInterfaces;
using Shared.Dtos;
using Shared.Models;

namespace Application.Logic;

public class AuthLogic : IAuthLogic {
    private readonly ILoginService _loginService;

    public AuthLogic(ILoginService loginService) {
        _loginService = loginService;
    }

    public async Task<Employee> ValidateEmployee(string username, string password) { //TODO implement proper exceptions
        Employee employee = await _loginService.ValidateEmployeeAsync(new EmployeeLoginDto { Password = password, UserId = username });
        return employee;
    }

    public Task RegisterEmployee(Employee employee) { //TODO implement proper exceptions
        _loginService.RegisterEmployee(new EmployeeCreationDto { Password = employee.Password, Username = employee.Username });

        return Task.CompletedTask;
    }    
}