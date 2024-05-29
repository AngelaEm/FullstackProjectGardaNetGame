using GardaNetGame.Shared.Entities;

namespace GardaNetGame.Shared.DTOs.Customer.Request;

public class AddCustomerRequest
{
	public Guid Id { get; set; }
	public string Email { get; set; }
	public List<Order> ListOfOrders { get; set; }
}