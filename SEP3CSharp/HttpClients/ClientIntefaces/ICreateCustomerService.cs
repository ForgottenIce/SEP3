using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientIntefaces;

public class ICreateCustomerService
{
    Task<Customer> CreateCustomerAsync(CreateCustomerDto dto);
    Task<IEnumerable<Customer>> GetCreateCustomerAsync();
    Task<Customer> GetCreateCustomerById(int id);
}