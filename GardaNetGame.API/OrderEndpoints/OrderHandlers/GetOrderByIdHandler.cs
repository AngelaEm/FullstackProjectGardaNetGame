using FastEndpoints;
using GardaNetGame.API.Mappers.Order.DomainToResponse;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class GetOrderByIdHandler(IOrderService<Order> repo) : Endpoint<IdRequest, OrdersResponse>
{
	public override void Configure()
	{
		Get("/orders/orderId/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(IdRequest request,CancellationToken ct)
	{
		var orderById = await repo.GetOrderById(request.Id);

		if (orderById is null)
		{
			await SendNotFoundAsync(ct);
		}
		

		await SendOkAsync(orderById.ToOrderByIdResponse(), ct);
	}
}