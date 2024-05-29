namespace GardaNetGame.Shared.DTOs.Customer.Request;

public class AddOrderToCustomerRequest
{
    public Guid CustomerId { get; set; }

    public Guid OrderId { get; set; }
}