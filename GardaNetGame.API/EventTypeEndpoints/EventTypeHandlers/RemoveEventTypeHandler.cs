using FastEndpoints;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventTypeEndpoints.EventTypeHandlers;

public class RemoveEventTypeHandler(IEventTypeService<EventType> repo) : Endpoint<IdRequest, EmptyResponse>
{
	public override void Configure()
	{
		Delete("/eventTypes/{id}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(IdRequest request, CancellationToken ct)
	{
		var eventTypeToRemove = await repo.GetEventTypeById(request.Id);

		if (eventTypeToRemove is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await repo.RemoveEventType(eventTypeToRemove);

		await SendOkAsync(new EmptyResponse(), ct);
	}
}
