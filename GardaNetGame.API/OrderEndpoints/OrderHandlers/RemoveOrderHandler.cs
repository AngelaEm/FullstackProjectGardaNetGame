using FastEndpoints;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class RemoveOrderHandler(IOrderService<Order> repo) : Endpoint<IdRequest, EmptyResponse>
{
	public override void Configure()
	{
		Delete("/orders/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(IdRequest request, CancellationToken ct)
	{
		var orderToRemove = await repo.GetOrderById(request.Id);

		if (orderToRemove is null)
		{
			await SendNotFoundAsync(ct);
		}

		await repo.RemoveOrder(orderToRemove);

		await SendOkAsync(new EmptyResponse(), ct);
	}
}