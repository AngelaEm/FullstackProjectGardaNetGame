using FastEndpoints;
using GardaNetGame.API.Mappers.Game.DomainToResponse;
using GardaNetGame.Shared.DTOs.Games.Request;
using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class GetGameByAgeRestrictionHandler(IGameService<Game> repo) : Endpoint<GetGameByAgeRestrictionRequest, GetGamesByAgeListResponse>
{
	public override void Configure()
	{
		Get("/games/ageRestriction/{ageRestriction}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(GetGameByAgeRestrictionRequest request, CancellationToken ct)
	{
		var gamesByAgeRestriction = await repo.GetGameByAgeRestriction(request.AgeRestriction);
	

		var response = new GetGamesByAgeListResponse()
		{
			Games = gamesByAgeRestriction.Select(g => g.ToGameResponse())
		};

		await SendOkAsync(response, ct);
	}
}