namespace GardaNetGame.Shared.DTOs.Games.Response;

public class GetGamesByAgeListResponse
{
	public IEnumerable<GameResponse> Games { get; set; } = Enumerable.Empty<GameResponse>();
}