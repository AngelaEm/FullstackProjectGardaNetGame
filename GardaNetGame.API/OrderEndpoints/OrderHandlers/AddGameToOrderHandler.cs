using FastEndpoints;
using GardaNetGame.Shared.DTOs.Orders.Requests;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class AddGameToOrderHandler(IOrderService<Order> orderRepo) : Endpoint<AddGameToOrderRequest, EmptyResponse>
{
    public override void Configure()
    {
        Patch("/orders/gameToOrder/{orderId}/{gameId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddGameToOrderRequest request, CancellationToken ct)
    {
        await orderRepo.AddGameToOrder(request.OrderId, request.GameId);

        await SendOkAsync(cancellation: ct);
    }
}