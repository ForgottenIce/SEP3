using Shared.Models;

namespace Application.LogicInterfaces;

public interface IPackageLogic
{
    Task<List<Package>> GetAllAsync();
}