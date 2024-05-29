namespace GardaNetGame.Shared.DTOs.Orders.Requests;

public class RemoveGameFromOrderRequest
{
    public Guid OrderId { get; set; }
    public Guid GameId { get; set; }
}