using FastEndpoints;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GenreEndpoints.GenreHandlers;

public class RemoveGenreHandler(IGenreService<Genre> repo) : Endpoint<IdRequest, EmptyResponse>
{
	public override void Configure()
	{
		Delete("/genres/{id}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(IdRequest request, CancellationToken ct)
	{
		var genreToRemove = await repo.GetGenreById(request.Id);

		if (genreToRemove is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await repo.RemoveGenre(genreToRemove);

		await SendOkAsync(new EmptyResponse(), ct);
	}
}