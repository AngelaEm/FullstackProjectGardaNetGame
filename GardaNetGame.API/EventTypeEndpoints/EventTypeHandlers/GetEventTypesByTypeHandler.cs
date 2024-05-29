using FastEndpoints;
using GardaNetGame.API.Mappers.EventType.DomainToResponse;
using GardaNetGame.Shared.DTOs.EventTypes.Request;
using GardaNetGame.Shared.DTOs.EventTypes.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventTypeEndpoints.EventTypeHandlers;

public class GetEventTypesByTypeHandler(IEventTypeService<EventType> repo) : Endpoint<GetEventTypeByTypeRequest, EventTypesResponse>
	
{
	public override void Configure()
	{
		Get("/eventTypes/type/{type}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(GetEventTypeByTypeRequest request, CancellationToken ct)
	{
		var eventTypesByType = await repo.GetEventTypeByName(request.Type);

		if (eventTypesByType is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await SendOkAsync(eventTypesByType.ToEventTypesResponse(), ct);

	}
}
