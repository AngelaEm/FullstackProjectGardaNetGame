using FastEndpoints;
using GardaNetGame.API.Mappers.Game.RequestToResponse;
using GardaNetGame.Shared.DTOs.Games.Request;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class AddGameHandler(IGameService<Game> repo) : Endpoint<AddGameRequest, EmptyResponse>
{
	public override void Configure()
	{
		Post("/games");
		AllowAnonymous();
	}

	public async override Task HandleAsync(AddGameRequest request, CancellationToken ct)
    {

        if (await repo.GetGameByName(request.Name) != null)
        {
			AddError(r => r.Name, $"A game with the name {request.Name} already exist");
			ThrowIfAnyErrors();
        }
         
		var addGame = request.ToAddGame();
		await repo.AddGame(addGame);
		await SendOkAsync(new EmptyResponse());
	}
} 