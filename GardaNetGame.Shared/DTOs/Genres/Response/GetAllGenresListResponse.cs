namespace GardaNetGame.Shared.DTOs.Genres.Response;

public class GetAllGenresListResponse
{
	public IEnumerable<GenresResponse> Genres { get; set; } = Enumerable.Empty<GenresResponse>();

}