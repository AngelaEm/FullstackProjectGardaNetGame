namespace GardaNetGame.Shared.Entities;

public class Customer
{
	public Guid Id { get; set; }
	public string Email { get; set; }
	public ICollection<Order>? ListOfOrders { get; set; } = new List<Order>();
}
