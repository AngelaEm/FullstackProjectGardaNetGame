using FastEndpoints;
using GardaNetGame.API.Mappers.Order.DomainToResponse;
using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class GetAllOrdersHandler(IOrderService<Order> repo) : EndpointWithoutRequest
{
	public override void Configure()
	{
		Get("/orders");
		AllowAnonymous();
	}

	public async override Task HandleAsync(CancellationToken ct)
	{
		var orders = await repo.GetAllOrders();

		var response = new GetAllOrdersListResponse()
		{
			Orders = orders.Select(x => x.ToOrdersResponse())
		};

		await SendOkAsync(response, ct);
	}
}