using FastEndpoints;
using GardaNetGame.API.Mappers.Game.DomainToResponse;
using GardaNetGame.Shared.DTOs.Games.Request;
using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class GetGameByIdHandler(IGameService<Game> repo) :Endpoint<GetGameByIdRequest, GameResponse>
{
	public override void Configure()
	{
		Get("/games/gameId/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(GetGameByIdRequest request, CancellationToken ct)
	{
		var gameById = await repo.GetGameById(request.Id);

		if (gameById is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await SendOkAsync(gameById.ToGameByIdResponse(), ct);
	}
}