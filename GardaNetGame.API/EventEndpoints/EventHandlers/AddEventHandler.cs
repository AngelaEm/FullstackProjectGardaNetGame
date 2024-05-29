using FastEndpoints;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using GardaNetGame.Shared.DTOs.Events.Request;
using GardaNetGame.API.Mappers.Event.DomainToResponse;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class AddEventHandler(IEventService<Event> repo) : Endpoint<AddEventRequest, EmptyResponse>
{
    public override void Configure()
    {
        Post("/events");
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddEventRequest request, CancellationToken ct)
    {
        var addEvent = request.ToAddEvent();
        await repo.AddEvent(addEvent);
        await SendOkAsync(new EmptyResponse());
    }
}
