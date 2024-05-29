namespace GardaNetGame.Shared.DTOs.Events.Response;

public class GetEventByStatusListResponse
{
	public IEnumerable<EventsResponse> Events { get; set; } = Enumerable.Empty<EventsResponse>();
}