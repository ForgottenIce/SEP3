using System.Text.Json;
using HttpClients.ClientInterfaces;
using Shared.Models;

namespace HttpClients.ClientImplementations;

public class PackageService: IPackageService
{
    private readonly HttpClient client;

    public PackageService(HttpClient client)
    {
        this.client = client;
    }
    

    public async Task<List<Package>> GetAllAsync()
    {
        HttpResponseMessage response = await client.GetAsync("http://localhost:5103/Package");
        string responseContent = await response.Content.ReadAsStringAsync();
       
            if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
            List<Package> packages= JsonSerializer.Deserialize<List<Package>>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return packages;


    }
}