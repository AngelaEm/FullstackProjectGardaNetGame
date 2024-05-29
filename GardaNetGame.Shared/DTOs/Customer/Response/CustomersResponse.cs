namespace GardaNetGame.Shared.DTOs.Customer.Response;

public class CustomersResponse
{
	public Guid Id { get; set; }
	public string Email { get; set; }
	public ICollection<Guid>? ListOfOrderId { get; set; } = new List<Guid>();
}