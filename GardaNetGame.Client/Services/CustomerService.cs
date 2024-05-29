using GardaNetGame.Shared.DTOs.Customer.Response;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.Client.Services;

public class CustomerService : ICustomerService<CustomersResponse>
{
	private readonly HttpClient _httpClient;

	public CustomerService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("gardaNetGameApi");
	}

	public async Task<IEnumerable<CustomersResponse>> GetAllCustomers()
	{
		var response = await _httpClient.GetAsync("/customers");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<CustomersResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetAllCustomersListResponse>();
		return result.Customers ?? Enumerable.Empty<CustomersResponse>();
	}

	public async Task<CustomersResponse?> GetCustomerById(Guid id)
	{
		var response = await _httpClient.GetAsync($"/customers/customerId/{id}");

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<CustomersResponse>();
		return result;
	}

	public async Task <CustomersResponse> GetCustomerByEmail(string email)
	{
		var response = await _httpClient.GetAsync($"customers/email/{email}");

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<CustomersResponse>();
		return result;
	}

	public async Task AddCustomer(CustomersResponse customer)
	{
		var response = await _httpClient.PostAsJsonAsync($"customers", customer);
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public async Task UpdateCustomer(CustomersResponse customer)
	{
		var response = await _httpClient.PutAsJsonAsync($"customers/{customer.Id}", customer);
	}

	public async Task DeleteCustomer(CustomersResponse customer)
	{
		var response = await _httpClient.DeleteAsync($"customers/{customer.Id}");
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}
}