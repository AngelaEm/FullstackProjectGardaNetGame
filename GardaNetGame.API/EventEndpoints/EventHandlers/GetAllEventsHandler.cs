using FastEndpoints;
using GardaNetGame.API.Mappers.Event.DomainToResponse;
using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class GetAllEventsHandler(IEventService<Event> repo) : EndpointWithoutRequest
{

    public override void Configure()
    {

        Get("/events");
        AllowAnonymous();
    }


    public async override Task HandleAsync(CancellationToken ct)
    {
        var events = await repo.GetAllEvents();

        var response = new GetAllEventsListResponse()
        {
            Events = events.Select(x => x.ToEventsResponse())
        };

        await SendOkAsync(response, ct);
    }
}