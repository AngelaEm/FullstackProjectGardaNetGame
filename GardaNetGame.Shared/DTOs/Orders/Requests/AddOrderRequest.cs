using GardaNetGame.Shared.Entities;

namespace GardaNetGame.Shared.DTOs.Orders.Requests;

public class AddOrderRequest
{
	public Guid Id { get; set; }

	public List<Event> Events { get; set; }

	public List<Game> Games { get; set; }
	public bool IsActive { get; set; }
}