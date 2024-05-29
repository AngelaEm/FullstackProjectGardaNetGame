using GardaNetGame.Shared.DTOs.Customer.Response;
using GardaNetGame.Shared.DTOs.Orders.Responses;

namespace GardaNetGame.API.Mappers.Customer.DomainToResponse;

public static class CustomerByIdMapper
{
	public static CustomerByIdResponse ToCustomerByIdResponse(this Shared.Entities.Customer customer)
	{

		var orderResponse = customer.ListOfOrders?.Select(orders => new OrdersResponse()
		{
			Id = orders.Id,
			Events = orders.Events,
			Games = orders.Games
		}).ToList();

		return new CustomerByIdResponse()
		{
			Id = customer.Id,
			Email = customer.Email,
			OrderList = orderResponse
		};
	}
}
