using FastEndpoints;
using GardaNetGame.API.Mappers.Game.RequestToResponse;
using GardaNetGame.Shared.DTOs.Games.Request;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class UpdateGameHandler(IGameService<Game> repo) : Endpoint<UpdateGameRequest, EmptyResponse>
{
	public override void Configure()
	{
		Put("games/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(UpdateGameRequest request, CancellationToken ct)
	{

        if (await repo.GetGameByName(request.Name) != null)
        {
            AddError(r => r.Name, $"A game with the name {request.Name} already exist");
            ThrowIfAnyErrors();
        }

        await repo.UpdateGame(request.ToGame());
		await SendOkAsync(new EmptyResponse(), ct);
	}
}