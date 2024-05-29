using FastEndpoints;
using GardaNetGame.API.Mappers.Genre.RequestToDomain;
using GardaNetGame.Shared.DTOs.Genres.Requests;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GenreEndpoints.GenreHandlers;


public class AddGenreHandler(IGenreService<Genre> repo) : Endpoint<AddGenreRequest, EmptyResponse>
	{
		public override void Configure()
		{
			Post("/genres");
			AllowAnonymous();
		}

		public override async Task HandleAsync(AddGenreRequest request, CancellationToken ct)
        {
            var genreExist = await repo.GetGenreByName(request.Name);
            if (genreExist != null)
            {
                AddError(r => r.Name, $"{request.Name} already exist");
                ThrowIfAnyErrors();
                return;
            }
			var addGenre = request.ToAddGenre();
			await repo.AddGenre(addGenre);
			await SendOkAsync(new EmptyResponse());
		}
	}

