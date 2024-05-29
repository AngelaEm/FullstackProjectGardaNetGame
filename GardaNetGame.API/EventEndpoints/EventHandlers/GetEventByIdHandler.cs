using FastEndpoints;
using GardaNetGame.API.Mappers.Event.DomainToResponse;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class GetEventByIdHandler(IEventService<Event> repo) : Endpoint<IdRequest, EventsResponse>
{
    public override void Configure()
    {
        Get("/events/eventId/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(IdRequest request, CancellationToken ct)
    {
        var eventById = await repo.GetEventById(request.Id);

        if (eventById is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }


        await SendOkAsync(eventById.ToEventByIdResponse(), ct);
    }
}
