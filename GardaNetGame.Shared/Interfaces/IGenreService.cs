namespace GardaNetGame.Shared.Interfaces;

public interface IGenreService<T> where T : class
{
	Task<IEnumerable<T>> GetAllGenres();
	Task<T?> GetGenreById(Guid id);
	Task<T?> GetGenreByName(string name);
	Task AddGenre(T newGenre);
	Task UpdateGenre(T updateGenre);
	Task RemoveGenre(T genreToRemove);


}