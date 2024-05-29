namespace GardaNetGame.Shared.DTOs.Orders.Responses;

public class GetAllOrdersListResponse
{
	public IEnumerable<OrdersResponse> Orders { get; set; } = Enumerable.Empty<OrdersResponse>();
}