using FastEndpoints;
using GardaNetGame.API.Mappers.Order.DomainToResponse;
using GardaNetGame.Shared.DTOs.Orders.Requests;
using GardaNetGame.Shared.DTOs.Orders.Responses;
using GardaNetGame.Shared.Interfaces;
using Order = GardaNetGame.Shared.Entities.Order;

namespace GardaNetGame.API.OrderEndpoints.OrderHandlers;

public class AddEventToOrderHandler(IOrderService<Order> orderRepo) : Endpoint<AddEventToOrderRequest, OrdersResponse>
{
    public override void Configure()
    {
        Patch("/orders/eventToOrder/{orderId}/{eventId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddEventToOrderRequest request, CancellationToken ct)
    {
        await orderRepo.AddEventToOrder(request.OrderId, request.EventId, null);

        var orderById = await orderRepo.GetOrderById(request.OrderId);

        if (orderById is null)
        {
            await SendNotFoundAsync(ct);
        }

        await SendOkAsync(orderById.ToOrderResponse() , ct);
    }
}