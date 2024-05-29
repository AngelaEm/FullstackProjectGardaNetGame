using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.Client.Services;

public class OrderService : IOrderService<OrdersResponse>
{

	private readonly HttpClient _httpClient;

	public OrderService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("gardaNetGameApi");
	}

	public async Task<IEnumerable<OrdersResponse>> GetAllOrders()
	{
		var response = await _httpClient.GetAsync("/orders");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<OrdersResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetAllOrdersListResponse>();
		return result.Orders ?? Enumerable.Empty<OrdersResponse>();
	}

	public async Task<OrdersResponse?> GetOrderById(Guid id)
	{
		var response = await _httpClient.GetAsync("/orders/orderId/{id}");

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<OrdersResponse>();
		return result;
	}

	public async Task<OrdersResponse> AddOrder(OrdersResponse newOrder)
	{
		var response = await _httpClient.PostAsJsonAsync("/orders", newOrder);
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}
        var result = await response.Content.ReadFromJsonAsync<OrdersResponse>();
        return result;
    }

    public async Task AddEventToOrder(Guid orderId, Guid eventId, HttpContent content)
    {
		//var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Patch, $"/orders/eventToOrder/{orderId}/{eventId}"));
        var response = await _httpClient.PatchAsync($"/orders/eventToOrder/{orderId}/{eventId}", content);
    }

    public async Task AddGameToOrder(Guid orderId, Guid gameId)
    {
        var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Patch, $"/orders/gameToAdd?OrderId={orderId}&GameId={gameId}"));
    }

    public async Task UpdateOrder(OrdersResponse updateOrder)
	{
		var response = await _httpClient.PutAsJsonAsync($"/orders/update/{updateOrder.Id}", updateOrder);
		if (!response.IsSuccessStatusCode)
		{
			return ;
		}
	}

	public async Task RemoveOrder(OrdersResponse orderToRemove)
	{
		var response = await _httpClient.PutAsJsonAsync($"/orders/{orderToRemove.Id}", orderToRemove);
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

    public Task RemoveEventFromOrder(Guid orderId, Guid EventId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveGameFromOrder(Guid orderId, Guid GameId)
    {
        throw new NotImplementedException();
    }

    public async Task<OrdersResponse?> GetOrderIfActive()
	{
		var orders = await GetAllOrders(); 

		return orders.FirstOrDefault(o => o.IsActive);
	}
}