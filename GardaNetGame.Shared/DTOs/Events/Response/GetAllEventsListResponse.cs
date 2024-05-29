namespace GardaNetGame.Shared.DTOs.Events.Response;

public class GetAllEventsListResponse
{
	public IEnumerable<EventsResponse> Events { get; set; } = Enumerable.Empty<EventsResponse>();
}