using FastEndpoints;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class RemoveGameHandler(IGameService<Game> repo) : Endpoint<IdRequest, EmptyResponse>
{
	public override void Configure()
	{
		Delete("/games/{id}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(IdRequest request, CancellationToken ct)
	{
		var gameToDelete = await repo.GetGameById(request.Id);

		if (gameToDelete is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await repo.RemoveGame(gameToDelete);
		await SendOkAsync(new EmptyResponse(), ct);
	}
}