namespace GardaNetGame.Shared.DTOs.Events.Response;

public class GetEventByTypeListResponse
{
	public IEnumerable<EventsResponse> Events { get; set; } = Enumerable.Empty<EventsResponse>();

}