using FastEndpoints;
using GardaNetGame.API.Mappers.Game.DomainToResponse;
using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class GetAllGamesHandler(IGameService<Game> repo) : EndpointWithoutRequest
{
	public override void Configure()
	{
		Get("/games");
		AllowAnonymous();
	}

	public async override Task HandleAsync(CancellationToken ct)
	{
		var games = await repo.GetAllGames();

		var response = new GetGamesListResponse()
		{
			Games = games.Select(g => g.ToGameResponse())
		};

		await SendOkAsync(response, ct);
	}
}