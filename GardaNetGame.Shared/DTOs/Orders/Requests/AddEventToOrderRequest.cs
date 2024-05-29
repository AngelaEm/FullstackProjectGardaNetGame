namespace GardaNetGame.Shared.DTOs.Orders.Requests;

public class AddEventToOrderRequest
{
    public Guid OrderId { get; set; }

    public Guid EventId { get; set; }
}