namespace GardaNetGame.Shared.DTOs.Customer.Response;

public class GetAllCustomersListResponse
{
	public IEnumerable<CustomersResponse> Customers { get; set; } = Enumerable.Empty<CustomersResponse>();
}