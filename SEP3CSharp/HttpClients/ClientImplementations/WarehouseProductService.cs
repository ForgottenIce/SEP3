using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.ClientIntefaces;
using Shared.Dtos;
using Shared.Models;

namespace HttpClients.ClientImplementations; 

public class WarehouseProductService : IWarehouseProductService {
	private readonly HttpClient _httpClient;

	public WarehouseProductService(HttpClient httpClient) {
		_httpClient = httpClient;
	}

	public async Task<WarehouseProduct> CreateWarehouseProductAsync(WarehouseProductCreationDto dto) {
		HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/warehouseProduct", dto);
		string content = await response.Content.ReadAsStringAsync();
		
		if (!response.IsSuccessStatusCode) {
			string result = await response.Content.ReadAsStringAsync();
			throw new Exception(result);
		}

		WarehouseProduct warehouseProduct = JsonSerializer.Deserialize<WarehouseProduct>(content,
			new JsonSerializerOptions {
				PropertyNameCaseInsensitive = true
			})!;
		return warehouseProduct;
	}
	[Obsolete("not working right",true)]
	public async Task<WarehouseProduct> GetWarehouseProductById(long productId, long warehouseId) {
		HttpResponseMessage response = await _httpClient.GetAsync($"/warehouseProduct/byid?productId={productId}&warehouseId={warehouseId}");
		string content = await response.Content.ReadAsStringAsync();

		if (!response.IsSuccessStatusCode) {
			string result = await response.Content.ReadAsStringAsync();
			throw new Exception(result);
		}

		WarehouseProduct warehouseProduct = JsonSerializer.Deserialize<WarehouseProduct>(content,
			new JsonSerializerOptions {
				PropertyNameCaseInsensitive = true
			})!;
		return warehouseProduct;
	}

	public async Task<IEnumerable<WarehouseProduct>> GetWarehouseProductsAsync() {
		HttpResponseMessage response = await _httpClient.GetAsync("/warehouseProduct");
		string content = await response.Content.ReadAsStringAsync();

		if (!response.IsSuccessStatusCode) {
			string result = await response.Content.ReadAsStringAsync();
			throw new Exception(result);
		}
		
		IEnumerable<WarehouseProduct> warehouseProducts = JsonSerializer.Deserialize<IEnumerable<WarehouseProduct>>(content,
			new JsonSerializerOptions {
				PropertyNameCaseInsensitive = true
			})!;
		return warehouseProducts;
	}
}