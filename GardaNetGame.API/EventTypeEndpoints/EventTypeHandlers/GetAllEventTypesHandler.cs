using FastEndpoints;
using GardaNetGame.API.Mappers.EventType.DomainToResponse;
using GardaNetGame.Shared.DTOs.EventTypes.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.EventTypeEndpoints.EventTypeHandlers;

public class GetAllEventTypesHandler(IEventTypeService<EventType> repo) : EndpointWithoutRequest
{
	public override void Configure()
	{
		Get("/eventTypes");
		AllowAnonymous();
	}

	public async override Task HandleAsync(CancellationToken ct)
	{
		var eventTypes = await repo.GetAllEventTypes();

		var response = new GetAllEventTypesListResponse()
		{
			EventTypes = eventTypes.Select(x => x.ToEventTypesResponse())
		};

		await SendOkAsync(response, ct);
	}
}

