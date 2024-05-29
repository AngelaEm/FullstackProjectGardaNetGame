using GardaNetGame.Shared.DTOs.EventTypes.Response;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.Client.Services;

public class EventTypeService : IEventTypeService<EventTypesResponse>
{
	private readonly HttpClient _httpClient;

	public EventTypeService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("gardaNetGameApi");
	}

	public async Task<IEnumerable<EventTypesResponse>> GetAllEventTypes()
	{
		var response = await _httpClient.GetAsync("/eventTypes");
		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<EventTypesResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetAllEventTypesListResponse>();
		return result.EventTypes ?? Enumerable.Empty<EventTypesResponse>();
	}

	public async Task<EventTypesResponse?> GetEventTypeById(Guid id)
	{
		var response = await _httpClient.GetAsync($"eventTypes/eventTypeId/{id}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<EventTypesResponse>();
		return result;
	}

	public async Task<EventTypesResponse?> GetEventTypeByName(string type)
	{
		var response = await _httpClient.GetAsync($"/eventTypes/type/{type}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<EventTypesResponse>();
		return result;
	}

	public async Task AddEventType(EventTypesResponse newEventType)
	{
		var response = await _httpClient.PostAsJsonAsync("/eventTypes", newEventType);
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public Task UpdateEventType(EventTypesResponse updateEventType)
	{
		var response = _httpClient.PutAsJsonAsync($"/eventTypes/update/{updateEventType.Id}", updateEventType);
		if (!response.Result.IsSuccessStatusCode)
		{
			return Task.CompletedTask;
		}
		return response;
	}


	public Task RemoveEventType(EventTypesResponse eventTypeToRemove)
	{
		var response = _httpClient.DeleteAsync($"/eventTypes/{eventTypeToRemove.Id}");
		if (!response.Result.IsSuccessStatusCode)
		{
			return Task.CompletedTask;
		}
		return response;
	}
}
