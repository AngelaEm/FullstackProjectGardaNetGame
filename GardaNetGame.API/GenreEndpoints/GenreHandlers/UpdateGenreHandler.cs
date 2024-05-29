using FastEndpoints;
using GardaNetGame.API.Mappers.Genre.RequestToDomain;
using GardaNetGame.Shared.DTOs.Genres.Requests;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GenreEndpoints.GenreHandlers;

public class UpdateGenreHandler(IGenreService<Genre> repo) : Endpoint<UpdateGenreRequest, EmptyResponse>
{
	public override void Configure()
	{
		Put("/genres/update/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(UpdateGenreRequest request, CancellationToken ct)
	{
        var genreExist = await repo.GetGenreByName(request.Name);
        if (genreExist != null)
        {
            AddError(r => r.Name, $"{request.Name} already exist");
            ThrowIfAnyErrors();
            return;
        }

        await repo.UpdateGenre(request.ToGenre());
		await SendOkAsync(new EmptyResponse(), ct);
	}
}