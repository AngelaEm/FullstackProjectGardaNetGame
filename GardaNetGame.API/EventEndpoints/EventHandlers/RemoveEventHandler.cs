using FastEndpoints;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class RemoveEventHandler(IEventService<Event> repo) : Endpoint<IdRequest, EmptyResponse>
{
    public override void Configure()
    {
        Delete("/events/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequest request, CancellationToken ct)
    {
        var eventToRemove = await repo.GetEventById(request.Id);

        if (eventToRemove is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await repo.RemoveEvent(eventToRemove);

        await SendOkAsync(new EmptyResponse(), ct);
    }
}
//