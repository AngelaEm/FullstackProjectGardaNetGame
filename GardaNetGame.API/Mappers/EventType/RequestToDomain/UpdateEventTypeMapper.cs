using GardaNetGame.Shared.DTOs.EventTypes.Request;

namespace GardaNetGame.API.Mappers.EventType.RequestToDomain;

public static class UpdateEventTypeMapper
{
	public static Shared.Entities.EventType ToEventType(this UpdateEventTypeRequest request)
	{
		return new Shared.Entities.EventType()
		{
			Id = request.Id,
			Type = request.Type,

		};
	}
}