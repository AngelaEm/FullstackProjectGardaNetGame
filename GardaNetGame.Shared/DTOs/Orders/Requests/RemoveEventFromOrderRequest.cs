namespace GardaNetGame.Shared.DTOs.Orders.Requests;

public class RemoveEventFromOrderRequest
{
    public Guid OrderId { get; set; }
    public Guid EventId { get; set; }
}