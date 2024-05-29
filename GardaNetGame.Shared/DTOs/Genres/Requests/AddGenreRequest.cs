namespace GardaNetGame.Shared.DTOs.Genres.Requests;

public class AddGenreRequest
{
	public Guid Id { get; set; } = new Guid();
	public string Name { get; set; }
}