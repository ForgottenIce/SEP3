using Shared.Models;

namespace HttpClients.ClientInterfaces;

public interface IPackageService
{
    Task<List<Package>> GetAllAsync();
}