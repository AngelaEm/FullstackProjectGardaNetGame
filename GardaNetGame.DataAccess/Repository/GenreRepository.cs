using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using MongoDB.Driver;

namespace GardaNetGame.DataAccess.Repository;

public class GenreRepository : IGenreService<Genre>
{
	private readonly IMongoDatabase db;
	private readonly IMongoCollection<Genre> _genresCollection;



	public GenreRepository()
	{
        var client = new MongoClient("mongodb://localhost:27017");
		db = client.GetDatabase("gardamongodb");
		_genresCollection = db.GetCollection<Genre>("Genres", new MongoCollectionSettings { AssignIdOnInsert = true });
	}

	public async Task<IEnumerable<Genre>> GetAllGenres()
	{
		var results = await _genresCollection.FindAsync(_ => true);
		return results.ToList();
	}

	public async Task<Genre?> GetGenreById(Guid id)
	{
		var filter = Builders<Genre>.Filter.Eq(g => g.Id, id);
		return await _genresCollection.Find(filter).FirstOrDefaultAsync();
	}

	public async Task<Genre?> GetGenreByName(string name)
	{
		var filter = Builders<Genre>.Filter.Eq(g => g.Name, name);
		return await _genresCollection.Find(filter).FirstOrDefaultAsync();
	}

	public Task AddGenre(Genre newGenre)
	{
		return _genresCollection.InsertOneAsync(newGenre);
	}

	public Task UpdateGenre(Genre updateGenre)
	{
		var filter = Builders<Genre>.Filter.Eq(g => g.Id, updateGenre.Id);
		return _genresCollection.ReplaceOneAsync(filter, updateGenre);
	}

	public async Task RemoveGenre(Genre genreToRemove)
	{
		var filter = Builders<Genre>.Filter.Eq(e => e.Id, genreToRemove.Id);
		await _genresCollection.DeleteOneAsync(filter);
	}
}