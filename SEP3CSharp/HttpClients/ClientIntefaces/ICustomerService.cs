using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientIntefaces;

public interface ICustomerService
{
    Task<Customer> CreateCustomerAsync(CustomerCreationDto dto);
    Task<IEnumerable<Customer>> GetCreateCustomerAsync();
    
}