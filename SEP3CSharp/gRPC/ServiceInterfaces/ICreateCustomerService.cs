using Shared.Dtos;
using Shared.Models;

namespace gRPC.ServiceInterfaces;

public interface ICreateCustomerService
{
    Task<Customer> CreateCustomerAsync(CreateCustomerDto dto);
    Task<IEnumerable<Customer>> GetCreateCustomerAsync();
    Task<Customer> GetCreateCustomerById(int id);
}