using HttpClients.ClientInterfaces;
using System.Text.Json;

namespace HttpClients.ClientImplementations;
public class PingService : IPingService {
    private readonly HttpClient client;

    public PingService(HttpClient client) { 
       this.client = client;
    }
    public async Task<long[]?> PingAsync() {
        HttpResponseMessage response = await client.GetAsync("/Ping");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            throw new Exception(result); //TODO implement more telling exception
        }

        long[]? dateTimes = JsonSerializer.Deserialize<long[]>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return dateTimes;
    }
}
