using FastEndpoints;
using GardaNetGame.API.Mappers.EventType.DomainToResponse;
using GardaNetGame.Shared.DTOs.EventTypes.Request;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventTypeEndpoints.EventTypeHandlers;

public class AddEventTypeHandler(IEventTypeService<EventType> repo) : Endpoint<AddEventTypeRequest, EmptyResponse>
{
	public override void Configure()
	{
		Post("/eventTypes");
		AllowAnonymous();
	}

	public override async Task HandleAsync(AddEventTypeRequest request, CancellationToken ct)
    {
        var eventTypeExist = await repo.GetEventTypeByName(request.Type);

        if (eventTypeExist != null)
        {
            AddError(r => r.Type, $"{request.Type} already exist");
            ThrowIfAnyErrors();
            return;
        }
		var addEventType = request.ToAddEventType();
		await repo.AddEventType(addEventType);
		await SendOkAsync(new EmptyResponse());
	}
}
