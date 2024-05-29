using GardaNetGame.Shared.DTOs.Games.Response;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.Client.Services;

public class GameService : IGameService<GameResponse>
{
	private readonly HttpClient _httpClient;

	public GameService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("gardaNetGameApi");
	}

	public async Task<IEnumerable<GameResponse>> GetAllGames()
	{
		var response = await _httpClient.GetAsync("/games");
		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<GameResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetGamesListResponse>();
		return result.Games ?? Enumerable.Empty<GameResponse>();
	}

	public async Task<GameResponse> GetGameById(Guid id)
	{
		var response = await _httpClient.GetAsync($"/games/gameId/{id}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<GameResponse>();
		return result;
	}

	public async Task<GameResponse> GetGameByName(string name)
	{
		var response = await _httpClient.GetAsync($"/games/name/{name}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<GameResponse>();
		return result;
	}

	public async Task<IEnumerable<GameResponse>> GetGameByDeveloper(string gameDeveloper)
	{
		var response = await _httpClient.GetAsync($"games/gameDeveloper/{gameDeveloper}");
		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<GameResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetGamesListResponse>();
		return result.Games ?? Enumerable.Empty<GameResponse>();
	}

	public async Task<IEnumerable<GameResponse>> GetGameByAgeRestriction(int age)
	{
		var response = await _httpClient.GetAsync($"games/ageRestriction/{age}");
		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<GameResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetGamesListResponse>();
		return result.Games ?? Enumerable.Empty<GameResponse>();
	}

	public async Task<IEnumerable<GameResponse>> GetGameByGenre(Guid genreId)
	{
		var response = await _httpClient.GetAsync($"games/genre/{genreId}");
		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<GameResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetGamesListResponse>();
		return result.Games ?? Enumerable.Empty<GameResponse>();
	}

	public async Task AddGame(GameResponse newGame)
	{
		var response = await _httpClient.PostAsJsonAsync("/games", newGame);
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public async Task UpdateGame(GameResponse updateEvent)
	{
		var response = await _httpClient.PutAsJsonAsync($"/games/{updateEvent.Id}", updateEvent);
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public async Task RemoveGame(GameResponse gameToDelete)
	{
		var response = await _httpClient.DeleteAsync($"/games/{gameToDelete.Id}");
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}
}