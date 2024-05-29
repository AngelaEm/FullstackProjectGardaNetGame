using GardaNetGame.Shared.Entities;

namespace GardaNetGame.Shared.DTOs.Customer.Request;

public class UpdateCustomerRequest
{
	public Guid Id { get; set; }
	public string Email { get; set; }
	public ICollection<Order>? ListOfOrders { get; set; } = new List<Order>();
}