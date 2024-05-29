using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.Client.Services;

public class EventService : IEventService<EventsResponse>
{
	private readonly HttpClient _httpClient;

	public EventService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("gardaNetGameApi");
	}

	public async Task<IEnumerable<EventsResponse>> GetAllEvents()
	{
		var response = await _httpClient.GetAsync("/events");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<EventsResponse>();
		}
		
		var result = await response.Content.ReadFromJsonAsync<GetAllEventsListResponse>();
		return result.Events ?? Enumerable.Empty<EventsResponse>();
	}

	public async Task<EventsResponse?> GetEventById(Guid id)
	{
		var response = await _httpClient.GetAsync($"/events/eventId/{id}");

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<EventsResponse>();
		return result;
	}

	public async Task<EventsResponse?> GetEventByName(string name)
	{
		var response = await _httpClient.GetAsync("/events/{name}");

		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<EventsResponse>();
		return result;
	}

	public async Task<IEnumerable<EventsResponse>> GetEventByType(Guid eventTypeId)
	{
		var response = await _httpClient.GetAsync($"/events/eventId/{eventTypeId}");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<EventsResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetEventByTypeListResponse>();
		return result.Events;
	}

	public async Task<IEnumerable<EventsResponse>> GetEventByStatus(bool status)
	{
		var response = await _httpClient.GetAsync($"/events/{status}");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<EventsResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetEventByStatusListResponse>();
		return result.Events;
	}

	public async Task AddEvent(EventsResponse newEvent)
	{
		var response = await _httpClient.PostAsJsonAsync("/events", newEvent);

		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public async Task UpdateEvent(EventsResponse updateEvent)
	{
		var response = await _httpClient.PutAsJsonAsync($"/events/update/{updateEvent.Id}", updateEvent);

		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public async Task RemoveEvent(EventsResponse eventToRemove)
	{
		var response = await _httpClient.DeleteAsync($"/events/{eventToRemove.Id}");

		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

}



