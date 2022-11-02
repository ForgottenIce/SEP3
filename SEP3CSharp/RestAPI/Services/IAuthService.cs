using Shared.Models;

namespace RestAPI.Services;

public interface IAuthService
{
    Task<bool> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}