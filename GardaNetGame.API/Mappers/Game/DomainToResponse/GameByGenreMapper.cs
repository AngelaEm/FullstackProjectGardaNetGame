using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.DTOs.Genres.Response;

namespace GardaNetGame.API.Mappers.Game.DomainToResponse;

public static class GameByGenreMapper
{
	public static GameResponse ToGameByGenreResponse(this Shared.Entities.Game game)
	{
		var genreResponses = game.Genre.Select(genre => new GenresResponse()
		{
			Id = genre.Id,
			Name = genre.Name
		}).ToList();

		return new GameResponse()
		{
			Id = game.Id,
			Name = game.Name,
			Genre = genreResponses,
			Price = game.Price,
			Description = game.Description,
			GameDeveloper = game.GameDeveloper,
			Publisher = game.Publisher,
			PublicationDate = game.PublicationDate,
			Platform = game.Platform,
			AgeRestriction = game.AgeRestriction,
			NumberOfPlayers = game.NumberOfPlayers,
			Reviews = game.Reviews,
			Grade = game.Grade,
			SystemRequirement = game.SystemRequirement,
			OnlineFuntionality = game.OnlineFuntionality,
			ProductImageUrl = game.ProductImageUrl,
			BackgroundImageUrl = game.BackgroundImageUrl,
			VideoTrailer = game.VideoTrailer
		};
	}
}