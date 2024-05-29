using GardaNetGame.Shared.DTOs.Genres.Requests;

namespace GardaNetGame.API.Mappers.Genre.RequestToDomain;

public static class AddGenreMapper
{
    public static Shared.Entities.Genre ToAddGenre(this AddGenreRequest addGenre)
    {
        return new Shared.Entities.Genre()
        {
            Id = addGenre.Id,
            Name = addGenre.Name,
        };
    }
}