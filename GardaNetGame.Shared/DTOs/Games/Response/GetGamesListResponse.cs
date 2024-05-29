namespace GardaNetGame.Shared.DTOs.Games.Response;

public class GetGamesListResponse
{
	public IEnumerable<GameResponse> Games { get; set; } = Enumerable.Empty<GameResponse>();
}