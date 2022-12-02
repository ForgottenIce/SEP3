using Shared.Models;

namespace Application.LogicInterfaces;

public interface ICustomerLogic
{
    Task<IEnumerable<Customer>> GetCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(long id);
}