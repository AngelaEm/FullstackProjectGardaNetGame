namespace GardaNetGame.Shared.DTOs.Orders.Requests;

public class AddGameToOrderRequest
{
    public Guid OrderId { get; set; }

    public Guid GameId { get; set; }
}