using FastEndpoints;
using GardaNetGame.Shared.DTOs.Orders.Requests;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class RemoveEventFromOrderHandler(IOrderService<Order> orderRepo) : Endpoint<RemoveEventFromOrderRequest, EmptyResponse>
{
    public override void Configure()
    {
        Patch("/orders/eventFromOrder/{orderId}/{eventId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RemoveEventFromOrderRequest request, CancellationToken ct)
    {
        await orderRepo.RemoveEventFromOrder(request.OrderId, request.EventId);

        await SendOkAsync(cancellation: ct);
    }
}