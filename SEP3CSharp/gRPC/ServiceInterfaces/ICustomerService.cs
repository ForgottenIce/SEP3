using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;

public interface ICustomerService
{
    Task<Customer> CreateCustomerAsync(CustomerCreationDto dto);
    Task<IEnumerable<Customer>> GetCreateCustomerAsync();
    Task<Customer> GetCreateCustomerById(int id);
}