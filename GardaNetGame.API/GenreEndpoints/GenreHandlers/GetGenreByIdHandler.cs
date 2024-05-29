using FastEndpoints;
using GardaNetGame.API.Mappers.Genre.DomainToResponse;
using GardaNetGame.Shared.DTOs.Genres.Requests;
using GardaNetGame.Shared.DTOs.Genres.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GenreEndpoints.GenreHandlers;

public class GetGenreByIdHandler(IGenreService<Genre> repo) : Endpoint<GetGenreByIdRequest, GenresResponse>
{
	public override void Configure()
	{

		Get("/genres/genreId/{id}");
		AllowAnonymous();
	}


	public async override Task HandleAsync(GetGenreByIdRequest request,CancellationToken ct)
	{
		var genreById = await repo.GetGenreById(request.Id);

		if (genreById is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await SendOkAsync(genreById.ToGenreByIdResponse(), ct);
	}
}