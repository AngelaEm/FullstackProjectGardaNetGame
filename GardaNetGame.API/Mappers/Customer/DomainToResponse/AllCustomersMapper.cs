using GardaNetGame.Shared.DTOs.Customer.Response;

namespace GardaNetGame.API.Mappers.Customer.DomainToResponse;

public static class AllCustomersMapper
{

	public static CustomersResponse ToCustomerResponse(this Shared.Entities.Customer customer)
	{
		var orderIds = customer.ListOfOrders?.Select(order => order.Id).ToList();

		return new CustomersResponse()
		{
			Id = customer.Id,
			Email = customer.Email,
			ListOfOrderId = orderIds
		};
	}
}