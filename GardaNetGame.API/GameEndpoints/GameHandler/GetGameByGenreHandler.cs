using FastEndpoints;
using GardaNetGame.API.Mappers.Game.DomainToResponse;
using GardaNetGame.Shared.DTOs.Games.Request;
using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GameEndpoints.GameHandler;

public class GetGameByGenreHandler(IGameService<Game> repo) : Endpoint<GetGameByGenreRequest, GetGamesListResponse>
{
	public override void Configure()
	{
		Get("/games/genre/{genreId}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(GetGameByGenreRequest request, CancellationToken ct)
	{
		var gamesByGenre = await repo.GetGameByGenre(request.GenreId);

		var response = new GetGamesListResponse()
		{
			Games = gamesByGenre.Select(g => g.ToGameByGenreResponse())
		};

		await SendOkAsync(response, ct);
	}
	
}