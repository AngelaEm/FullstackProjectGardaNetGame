using GardaNetGame.Shared.DTOs.Genres.Response;

namespace GardaNetGame.API.Mappers.Genre.DomainToResponse;

public static class GenreByIdMapper
{
	public static GenresResponse ToGenreByIdResponse(this Shared.Entities.Genre genreById)
	{
		return new GenresResponse()
		{
			Id = genreById.Id,
			Name = genreById.Name
		};
	}
}