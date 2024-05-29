using GardaNetGame.Shared.DTOs.Games.Request;

namespace GardaNetGame.API.Mappers.Game.RequestToResponse;

public static class AddGameMapper
{
    public static Shared.Entities.Game ToAddGame(this AddGameRequest addGame)
    {
        var genres = addGame.Genre.Select(genre => new Shared.Entities.Genre()
        {
			Id = genre.Id,
			Name = genre.Name,
			
        }).ToList();

 

		return new Shared.Entities.Game()
        {
	        Id = addGame.Id,
	        Name = addGame.Name,
	        Genre = genres,
	        Price = addGame.Price,
	        Description = addGame.Description,
	        GameDeveloper = addGame.GameDeveloper,
	        Publisher = addGame.Publisher,
	        PublicationDate = addGame.PublicationDate,
	        Platform = addGame.Platsform,
	        AgeRestriction = addGame.AgeRestriction,
	        NumberOfPlayers = addGame.NumberOfPlayers,
	        Reviews = addGame.Reviews,
	        Grade = addGame.Grade,
	        SystemRequirement = addGame.SystemRequirement,
	        OnlineFuntionality = addGame.OnlineFuntionality,
	        ProductImageUrl = addGame.ProductImageUrl,
	        BackgroundImageUrl = addGame.BackgroundImageUrl,
	        VideoTrailer = addGame.VideoTrailer
        };

    }
}