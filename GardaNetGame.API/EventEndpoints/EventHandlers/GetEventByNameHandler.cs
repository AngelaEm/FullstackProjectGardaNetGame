using FastEndpoints;
using GardaNetGame.API.Mappers.Event.DomainToResponse;
using GardaNetGame.Shared.DTOs.Events.Request;
using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class GetEventByNameHandler(IEventService<Event> repo) : Endpoint<GetEventByNameRequest, EventsResponse>
{
    public override void Configure()
    {
        Get("/events/name/{EventName}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEventByNameRequest request, CancellationToken ct)
    {
        var eventByName = await repo.GetEventByName(request.EventName);

        if (eventByName is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }


        await SendOkAsync(eventByName.ToEventByNameResponse(), ct);
    }
}