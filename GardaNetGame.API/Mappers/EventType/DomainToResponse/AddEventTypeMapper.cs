using GardaNetGame.Shared.DTOs.EventTypes.Request;
namespace GardaNetGame.API.Mappers.EventType.DomainToResponse;

public static class AddEventTypeMapper
{
	public static Shared.Entities.EventType ToAddEventType(this AddEventTypeRequest request)
	{
		return new Shared.Entities.EventType
		{
			Id = request.Id,
			Type = request.Type,
		};
	}
	
}