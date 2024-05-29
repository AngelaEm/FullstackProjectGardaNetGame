using FastEndpoints;
using GardaNetGame.API.Mappers.EventType.RequestToDomain;
using GardaNetGame.Shared.DTOs.EventTypes.Request;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventTypeEndpoints.EventTypeHandlers;

public class UpdateEventTypeHandler(IEventTypeService<EventType> repo) : Endpoint<UpdateEventTypeRequest, EmptyResponse>
{
	public override void Configure()
	{
		Put("/eventTypes/update/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(UpdateEventTypeRequest request, CancellationToken ct)
	{
        var eventTypeExist = await repo.GetEventTypeByName(request.Type);

        if (eventTypeExist != null)
        {
            AddError(r => r.Type, $"{request.Type} already exist");
            ThrowIfAnyErrors();
            return;
        }

        await repo.UpdateEventType(request.ToEventType());
		await SendOkAsync(new EmptyResponse(), ct);
	}
}
