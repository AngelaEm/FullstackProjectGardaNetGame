using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.EventType.DomainToResponse;

public static class AllEventTypeMapper
{
	public static EventTypesResponse ToEventTypesResponse(this Shared.Entities.EventType eventTypes)
	{
		return new EventTypesResponse
		{
			Id = eventTypes.Id,
			Type = eventTypes.Type
		};
	}
}