using GardaNetGame.Shared.DTOs.Orders.Requests;

namespace GardaNetGame.API.Mappers.Order.RequestToDomain;

public static class UpdateOrderMapper
{
	public static Shared.Entities.Order ToUpdateOrder(this UpdateOrderRequest orderToUpdate)
	{
		return new Shared.Entities.Order
		{
			Id = orderToUpdate.Id,
			Events = orderToUpdate.Events,
			Games = orderToUpdate.Games
		};
	}
}