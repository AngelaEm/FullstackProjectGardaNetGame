using GardaNetGame.Shared.DTOs.Customer.Response;
using GardaNetGame.Shared.DTOs.Orders.Responses;

namespace GardaNetGame.API.Mappers.Customer.DomainToResponse;

public static class CustomerByEmailMapper
{
	public static CustomerByEmailResponse ToCustomerByEmailResponse(this Shared.Entities.Customer customer)
	{

		var orderResponse = customer.ListOfOrders?.Select(orders => new OrdersResponse()
		{
			Id = orders.Id,
			Events = orders.Events,
			Games = orders.Games
		}).ToList();

		return new CustomerByEmailResponse()
		{
			Id = customer.Id,
			Email = customer.Email,
			OrderList = orderResponse
		};
	}
}
