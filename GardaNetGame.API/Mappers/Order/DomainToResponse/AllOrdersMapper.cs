using GardaNetGame.Shared.DTOs.Orders.Responses;

namespace GardaNetGame.API.Mappers.Order.DomainToResponse;

public static class AllOrdersMapper
{
	public static OrdersResponse ToOrdersResponse(this Shared.Entities.Order order)
	{
		return new OrdersResponse()
		{
			Id = order.Id,
			Events = order.Events,
			Games = order.Games
		};
	}
}