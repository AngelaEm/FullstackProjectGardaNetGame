namespace GardaNetGame.Shared.Interfaces;

public interface IGameService<T> where T : class
{
	Task<IEnumerable<T>> GetAllGames();
	Task<T> GetGameById(Guid id);

	Task<T> GetGameByName(string name);

	Task<IEnumerable<T>> GetGameByDeveloper(string gameDeveloper);

	Task<IEnumerable<T>> GetGameByAgeRestriction(int age);

	Task<IEnumerable<T>> GetGameByGenre(Guid genreId);

	Task AddGame(T newGame);

	Task UpdateGame(T updateEvent);

	Task RemoveGame(T gameToDelete);
}