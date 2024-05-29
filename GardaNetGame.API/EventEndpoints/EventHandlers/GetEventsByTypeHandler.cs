using FastEndpoints;
using GardaNetGame.API.Mappers.Event.DomainToResponse;
using GardaNetGame.Shared.DTOs.Events.Request;
using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventEndpoints.EventHandlers;

public class GetEventsByTypeHandler(IEventService<Event> repo) : Endpoint<GetEventByTypeRequest, GetEventByTypeListResponse>
{
    public override void Configure()
    {
        Get("/events/type/{type}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetEventByTypeRequest request, CancellationToken ct)
    {
        var eventByType = await repo.GetEventByType(request.Type.Id);

        var response = new GetEventByTypeListResponse()
        {
            Events = eventByType.Select(x => x.ToEventByTypeResponse())
        };

        await SendOkAsync(response, ct);

    }
}