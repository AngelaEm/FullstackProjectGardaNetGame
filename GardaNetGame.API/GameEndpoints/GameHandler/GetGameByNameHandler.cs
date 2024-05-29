using FastEndpoints;
using GardaNetGame.API.Mappers.Game.DomainToResponse;
using GardaNetGame.Shared.DTOs.Games.Request;
using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class GetGameByNameHandler(IGameService<Game> repo) : Endpoint<GetGameByNameRequest, GameResponse>
{
	public override void Configure()
	{
		Get("/games/name/{name}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(GetGameByNameRequest request, CancellationToken ct)
	{
		var gameByName = await repo.GetGameByName(request.Name);

		if (gameByName is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await SendOkAsync(gameByName.ToGameByNameResponse());
	}
}