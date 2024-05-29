using GardaNetGame.Shared.DTOs.Orders.Responses;

namespace GardaNetGame.Shared.DTOs.Customer.Response;

public class CustomerByEmailResponse
{
	public Guid Id { get; set; }
	public string Email { get; set; }

	public ICollection<OrdersResponse> OrderList { get; set; } = new List<OrdersResponse>();
}