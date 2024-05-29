using GardaNetGame.Shared.DTOs.Orders.Responses;

namespace GardaNetGame.API.Mappers.Order.DomainToResponse;

public static class OrderByIdMapper
{
	public static OrdersResponse ToOrderByIdResponse(this Shared.Entities.Order orderById)
	{
		return new OrdersResponse()
		{
			Id = orderById.Id,
			Events = orderById.Events,
			Games = orderById.Games
		};
	}
}