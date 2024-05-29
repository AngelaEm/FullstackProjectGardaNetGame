using FastEndpoints;
using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Interfaces;
namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;
using Order = GardaNetGame.Shared.Entities.Order;

public class GetOrderIfActiveHandler : Endpoint<EmptyRequest, OrdersResponse>
{
	private IOrderService<Order> repo;

	public GetOrderIfActiveHandler(IOrderService<Order> repo)
	{
		this.repo = repo;
	}

	public override void Configure()
	{
		Get("/orders/active");
		AllowAnonymous(); 
	}

	public async override Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var activeOrder = await repo.GetOrderIfActive();

		if (activeOrder != null)
		{
			
			var response = new OrdersResponse
			{
				Id = activeOrder.Id,
				
			};

			await SendAsync(response, cancellation: ct);
		}
		else
		{
			await SendNotFoundAsync(ct);
		}
	}
}