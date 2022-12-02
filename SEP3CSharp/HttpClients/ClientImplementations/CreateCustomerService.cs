using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientIntefaces;
using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientImplementations;

public class CreateCustomerService : ICreateCustomerService
{
    private readonly HttpClient _httpClient;

    public CreateCustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Customer> CreateCustomerAsync(CreateCustomerDto dto)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/CreateCustomer", dto);
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

    public async Task<IEnumerable<Customer>> GetCreateCustomerAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync()
    }
}