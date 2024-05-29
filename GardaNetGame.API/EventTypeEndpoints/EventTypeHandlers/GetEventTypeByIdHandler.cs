using FastEndpoints;
using GardaNetGame.API.Mappers.EventType.DomainToResponse;
using GardaNetGame.Shared.DTOs.EventTypes.Request;
using GardaNetGame.Shared.DTOs.EventTypes.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventTypeEndpoints.EventTypeHandlers;

public class GetEventTypeByIdHandler(IEventTypeService<EventType> repo) : Endpoint<GetEventTypeByIdRequest, EventTypesResponse>
{
	public override void Configure()
	{
		Get("/eventTypes/eventTypeId/{Id}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(GetEventTypeByIdRequest request, CancellationToken ct)
	{
		var eventTypeById = await repo.GetEventTypeById(request.Id);

		if (eventTypeById is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await SendOkAsync(eventTypeById.ToEventByTypeResponse());
	}
}
