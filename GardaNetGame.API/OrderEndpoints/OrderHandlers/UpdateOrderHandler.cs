using FastEndpoints;
using GardaNetGame.API.Mappers.Order.RequestToDomain;
using GardaNetGame.Shared.DTOs.Orders.Requests;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class UpdateOrderHandler(IOrderService<Order> repo) : Endpoint<UpdateOrderRequest, EmptyResponse>
{
	public override void Configure()
	{
		Put("/orders/update/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(UpdateOrderRequest request, CancellationToken ct)
	{
		var orderToUpdate = request.ToUpdateOrder();
		await repo.UpdateOrder(orderToUpdate);
		await SendOkAsync(new EmptyResponse());
	}
}