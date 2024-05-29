using FastEndpoints;
using GardaNetGame.API.Mappers.Order.DomainToResponse;
using GardaNetGame.API.Mappers.Order.RequestToDomain;
using GardaNetGame.Shared.DTOs.Orders.Requests;
using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class AddOrderHandler(IOrderService<Order> repo) : Endpoint<AddOrderRequest, OrdersResponse>
{
	public override void Configure()
	{
		Post("/orders");
		AllowAnonymous();
	}

	public async override Task HandleAsync(AddOrderRequest request,CancellationToken ct)
	{
		var newOrder = request.ToAddOrder();
		await repo.AddOrder(newOrder);
		//await SendOkAsync(new EmptyResponse());

        var orderById = await repo.GetOrderById(newOrder.Id);

        if (orderById is null)
        {
            await SendNotFoundAsync(ct);
        }

        await SendOkAsync(orderById.ToOrderResponse(), ct);
    }
}