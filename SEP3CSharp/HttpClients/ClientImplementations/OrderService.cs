using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientIntefaces;
using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientImplementations;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<Order> CreateOrderAsync(OrderCreationDto dto)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/CreateOrder", dto);
        string content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            throw new Exception(result);
        }

        Order order = JsonSerializer.Deserialize<Order>(content, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        })!;
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("/CreateOrder"); // Url er ikke right sat
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        IEnumerable<Order> orders = JsonSerializer.Deserialize<IEnumerable<Order>>(content,
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            })!;
        return orders;
    }
}