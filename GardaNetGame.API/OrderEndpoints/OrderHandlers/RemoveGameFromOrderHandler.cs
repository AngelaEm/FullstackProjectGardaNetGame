using FastEndpoints;
using GardaNetGame.Shared.DTOs.Orders.Requests;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class RemoveGameFromOrderHandler(IOrderService<Order> orderRepo) : Endpoint<RemoveGameFromOrderRequest, EmptyResponse>
{
     public override void Configure()
    {
        Patch("/orders/gameFromOrder/{orderId}/{gameId}");  
        AllowAnonymous();
    }

    public override async Task HandleAsync(RemoveGameFromOrderRequest request, CancellationToken ct)
    {
        await orderRepo.RemoveGameFromOrder(request.OrderId, request.GameId);

        await SendOkAsync(cancellation: ct);
    }
}