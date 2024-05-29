using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.EventType.DomainToResponse;

public static class GetEventTypeByTypeMapper
{
	public static EventTypesResponse ToEventByTypeResponse(this Shared.Entities.EventType eventTypeByType)
	{
		return new EventTypesResponse()
		{
			Id = eventTypeByType.Id,
			Type = eventTypeByType.Type,
		};
	}
}