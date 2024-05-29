using FastEndpoints;
using GardaNetGame.API.Mappers.Event.DomainToResponse;
using GardaNetGame.Shared.DTOs.Events.Request;
using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class GetEventsByStatusHandler(IEventService<Event> repo) : Endpoint<GetEventByStatusRequest, GetEventByStatusListResponse>
{
    public override void Configure()
    {
        Get("/events/status/{status}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(GetEventByStatusRequest request, CancellationToken ct)
    {
        var eventByStatus = await repo.GetEventByStatus(request.Status);

        var response = new GetEventByStatusListResponse()
        {
            Events = eventByStatus.Select(e => e.ToEventByStatusResponse())
        };


        await SendOkAsync(response, ct);
    }
}