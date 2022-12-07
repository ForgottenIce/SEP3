using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientIntefaces;
using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientImplementations;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Customer> CreateCustomerAsync(CustomerCreationDto dto)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/Customer", dto);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            throw new Exception(result);
        }

        Customer customer = JsonSerializer.Deserialize<Customer>(content, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        })!;
        return customer;
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("/Customer");
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        IEnumerable<Customer> customers = JsonSerializer.Deserialize<IEnumerable<Customer>>(content,
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            })!;
        return customers;
    }
}