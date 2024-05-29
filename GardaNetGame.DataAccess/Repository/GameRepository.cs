using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using MongoDB.Driver;

namespace GardaNetGame.DataAccess.Repository;

public class GameRepository : IGameService<Game>
{
	private readonly IMongoDatabase db;
	private readonly IMongoCollection<Game> _gamesCollection;

	public GameRepository()
	{
        var client = new MongoClient("mongodb://localhost:27017");
		db = client.GetDatabase("gardamongodb");
		_gamesCollection = db.GetCollection<Game>("Games", new MongoCollectionSettings { AssignIdOnInsert = true });
	}



	public async Task<IEnumerable<Game>> GetAllGames()
	{
		var allGames = await _gamesCollection.FindAsync(_ => true);
		return allGames.ToList();
	}

	public async Task<Game> GetGameById(Guid id)
	{
		var filter = Builders<Game>.Filter.Eq(e => e.Id, id); 
		var gameWithId = await _gamesCollection.Find(filter).FirstOrDefaultAsync();
		return gameWithId;
	}

	public async Task<Game> GetGameByName(string name)
	{
		var filter = Builders<Game>.Filter.Eq(e => e.Name, name);
		var gameWithName = await _gamesCollection.Find(filter).FirstOrDefaultAsync();
		return gameWithName;
	}

	public async Task<IEnumerable<Game>> GetGameByDeveloper(string gameDeveloper)
	{
		var filter = Builders<Game>.Filter.Eq(e => e.GameDeveloper, gameDeveloper);
		var gamesByDeveloper = await _gamesCollection.Find(filter).ToListAsync();
		return gamesByDeveloper;
	}

	public async Task<IEnumerable<Game>> GetGameByAgeRestriction(int age)
	{
		var filter = Builders<Game>.Filter.Eq(e => e.AgeRestriction, age);
		var gamesWithRestriction = await _gamesCollection.Find(filter).ToListAsync();
		return gamesWithRestriction;
	}

	public async Task<IEnumerable<Game>> GetGameByGenre(Guid genreId)
	{
		var filter = Builders<Game>.Filter.ElemMatch(game => game.Genre, genre => genre.Id == genreId);
		var gamesWithGenre = await _gamesCollection.Find(filter).ToListAsync();
		return gamesWithGenre;
	}

	public Task AddGame(Game newGame)
	{
		return _gamesCollection.InsertOneAsync(newGame);
	}

	public Task UpdateGame(Game updateEvent)
	{
		var filter = Builders<Game>.Filter.Eq(e => e.Id, updateEvent.Id);
		return _gamesCollection.ReplaceOneAsync(filter, updateEvent);
	}

	public async Task RemoveGame(Game gameToDelete)
	{
		var filter = Builders<Game>.Filter.Eq(e => e.Id, gameToDelete.Id);
		await _gamesCollection.DeleteOneAsync(filter);
	}
}