namespace GardaNetGame.Shared.DTOs.EventTypes.Response;

public class GetAllEventTypesListResponse
{
	public IEnumerable<EventTypesResponse> EventTypes { get; set; } = Enumerable.Empty<EventTypesResponse>();
}