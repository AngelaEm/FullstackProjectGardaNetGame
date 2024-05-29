using GardaNetGame.Shared.Entities;

namespace GardaNetGame.Shared.DTOs.Orders.Responses;

public class OrdersResponse
{
	public Guid Id { get; set; }

	public List<Event>? Events { get; set; } = new List<Event>();
	public double TotalValue { get; set; }

    public List<Game>? Games { get; set; } = new List<Game>();
    public bool IsActive { get; set; }
}