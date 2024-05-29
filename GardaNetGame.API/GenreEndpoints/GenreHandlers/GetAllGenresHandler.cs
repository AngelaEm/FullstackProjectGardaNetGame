using FastEndpoints;
using GardaNetGame.API.Mappers.Genre.DomainToResponse;
using GardaNetGame.Shared.DTOs.Genres.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.GenreEndpoints.GenreHandlers;



	public class GetAllGenresHandler(IGenreService<Genre> repo) : EndpointWithoutRequest
	{

		public override void Configure()
		{

			Get("/genres");
			AllowAnonymous();
		}


		public async override Task HandleAsync(CancellationToken ct)
		{
			var genres = await repo.GetAllGenres();

			var response = new GetAllGenresListResponse()
			{
			    Genres = genres.Select(x => x.ToGenresResponse())
			};

			await SendOkAsync(response, ct);
		}
	}
