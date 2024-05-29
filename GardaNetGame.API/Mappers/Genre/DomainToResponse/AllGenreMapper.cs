using GardaNetGame.Shared.DTOs.Genres.Response;

namespace GardaNetGame.API.Mappers.Genre.DomainToResponse;

public static class AllGenreMapper
{
	public static GenresResponse ToGenresResponse(this Shared.Entities.Genre genres)
	{
		return new GenresResponse()
		{
			Id = genres.Id,
			Name = genres.Name
		};
	}
}