using FastEndpoints;
using GardaNetGame.API.Mappers.Event.RequestToDomain;
using GardaNetGame.Shared.DTOs.Events.Request;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class UpdateEventHandler(IEventService<Event> repo) : Endpoint<UpdateEventRequest, EmptyResponse>
{
    public override void Configure()
    {
        Put("/events/update/{id}");
        AllowAnonymous();
    }


    public async override Task HandleAsync(UpdateEventRequest request, CancellationToken ct)
    {

        await repo.UpdateEvent(request.ToEvent());

        await SendOkAsync(new EmptyResponse(), ct);
    }
}