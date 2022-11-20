using Shared.Models;

namespace Application.LogicInterfaces;

public interface IAuthLogic
{
    Task<bool> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}