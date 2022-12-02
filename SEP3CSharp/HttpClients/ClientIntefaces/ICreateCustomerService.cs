using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientIntefaces;

public interface ICreateCustomerService
{
    Task<Customer> CreateCustomerAsync(CustomerCreationDto dto);
    Task<IEnumerable<Customer>> GetCreateCustomerAsync();
    
}