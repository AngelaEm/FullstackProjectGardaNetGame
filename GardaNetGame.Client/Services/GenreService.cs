using GardaNetGame.Shared.DTOs.Genres.Response;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.Client.Services;

public class GenreService : IGenreService<GenresResponse>
{
	private readonly HttpClient _httpClient;

	public GenreService(IHttpClientFactory factory)
	{
		_httpClient = factory.CreateClient("gardaNetGameApi");
	}

	public async Task<IEnumerable<GenresResponse>> GetAllGenres()
	{
		var response = await _httpClient.GetAsync("/genres");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<GenresResponse>();
		}

		var result = await response.Content.ReadFromJsonAsync<GetAllGenresListResponse>();
		return result.Genres ?? Enumerable.Empty<GenresResponse>();
	}

	public async Task<GenresResponse?> GetGenreById(Guid id)
	{
		var response = await _httpClient.GetAsync($"genres/genreId/{id}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<GenresResponse>();
		return result;
	}

	public async Task<GenresResponse?> GetGenreByName(string name)
	{
		var response = await _httpClient.GetAsync($"/genres/name/{name}");
		if (!response.IsSuccessStatusCode)
		{
			return null;
		}

		var result = await response.Content.ReadFromJsonAsync<GenresResponse>();
		return result;
	}

	public async Task AddGenre(GenresResponse newGenre)
	{
		var response = await _httpClient.PostAsJsonAsync("/genres", newGenre);
		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public Task UpdateGenre(GenresResponse updateGenre)
	{
		var response = _httpClient.PutAsJsonAsync($"/genres/update/{updateGenre.Id}", updateGenre);
		if (!response.Result.IsSuccessStatusCode)
		{
			return Task.CompletedTask;
		}
		return response;
	}

	public Task RemoveGenre(GenresResponse genreToRemove)
	{
		var response = _httpClient.DeleteAsync($"/genres/{genreToRemove.Id}");
		if (!response.Result.IsSuccessStatusCode)
		{
			return Task.CompletedTask;
		}
		return response;
	}
}