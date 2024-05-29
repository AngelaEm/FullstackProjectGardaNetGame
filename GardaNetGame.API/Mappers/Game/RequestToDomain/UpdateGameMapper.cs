using GardaNetGame.Shared.DTOs.Games.Request;

namespace GardaNetGame.API.Mappers.Game.RequestToResponse;

public static class UpdateGameMapper
{
	public static Shared.Entities.Game ToGame(this UpdateGameRequest updateGame)
	{

		var genres = updateGame.Genre.Select(genre => new Shared.Entities.Genre()
		{
			Id = genre.Id,
			Name = genre.Name,

		}).ToList();




		return new Shared.Entities.Game()
		{
			Id = updateGame.Id,
			Name = updateGame.Name,
			Genre = genres,
			Price = updateGame.Price,
			Description = updateGame.Description,
			GameDeveloper = updateGame.GameDeveloper,
			Publisher = updateGame.Publisher,
			PublicationDate = updateGame.PublicationDate,
			Platform = updateGame.Platsform,
			AgeRestriction = updateGame.AgeRestriction,
			NumberOfPlayers = updateGame.NumberOfPlayers,
			Reviews = updateGame.Reviews,
			Grade = updateGame.Grade,
			SystemRequirement = updateGame.SystemRequirement,
			OnlineFuntionality = updateGame.OnlineFuntionality,
			ProductImageUrl = updateGame.ProductImageUrl,
			BackgroundImageUrl = updateGame.BackgroundImageUrl,
			VideoTrailer = updateGame.VideoTrailer
		};

	}
}