using GardaNetGame.Shared.DTOs.Genres.Requests;

namespace GardaNetGame.API.Mappers.Genre.RequestToDomain;

public static class UpdateGenreMapper
{
	public static Shared.Entities.Genre ToGenre(this UpdateGenreRequest updateGenre)
	{
		return new Shared.Entities.Genre()
		{
			Id = updateGenre.Id,
			Name = updateGenre.Name,

		};
	}
}