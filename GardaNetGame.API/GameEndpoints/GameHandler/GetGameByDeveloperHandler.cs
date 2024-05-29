using FastEndpoints;
using GardaNetGame.API.Mappers.Game.DomainToResponse;
using GardaNetGame.Shared.DTOs.Games.Request;
using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class GetGameByDeveloperHandler(IGameService<Game> repo) : Endpoint<GetGameByDeveloperRequest, GetGamesListResponse>
{
	public override void Configure()
	{
		Get("/games/gameDeveloper/{gameDeveloper}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(GetGameByDeveloperRequest request, CancellationToken ct)
	{
		var gamesByDeveloper = await repo.GetGameByDeveloper(request.GameDeveloper);

		var response = new GetGamesListResponse()
		{
			Games = gamesByDeveloper.Select(g => g.ToGameResponse())
		};

		await SendOkAsync(response, ct);
	}
}