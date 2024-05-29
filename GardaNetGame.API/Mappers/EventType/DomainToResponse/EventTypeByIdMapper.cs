using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.EventType.DomainToResponse;

public static class EventTypeByIdMapper
{
	public static EventTypesResponse ToEventByIdResponse(this Shared.Entities.EventType eventTypeById)
	{
		return new EventTypesResponse()
		{
			Id = eventTypeById.Id,
			Type = eventTypeById.Type,
			
		};
	}
}