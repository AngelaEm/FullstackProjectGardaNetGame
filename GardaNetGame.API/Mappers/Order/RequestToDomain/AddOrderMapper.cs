using GardaNetGame.Shared.DTOs.Orders.Requests;

namespace GardaNetGame.API.Mappers.Order.RequestToDomain;

public static class AddOrderMapper
{
	public static Shared.Entities.Order ToAddOrder(this AddOrderRequest addOrder)
	{
		return new Shared.Entities.Order
		{
			Id = new Guid(),
			Events = addOrder.Events,
			Games = addOrder.Games
		};
	}
}