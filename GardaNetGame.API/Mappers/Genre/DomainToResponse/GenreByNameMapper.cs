using GardaNetGame.Shared.DTOs.Genres.Response;

namespace GardaNetGame.API.Mappers.Genre.DomainToResponse;

public static class GenreByNameMapper
{
	public static GenresResponse ToGenreByName(this Shared.Entities.Genre genreByName)
	{
		return new GenresResponse()
		{
			Id = genreByName.Id,
			Name = genreByName.Name,
		};
	}
}