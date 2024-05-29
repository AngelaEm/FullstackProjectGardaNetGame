using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using MongoDB.Driver;

namespace GardaNetGame.DataAccess.Repository;

public class EventRepository : IEventService<Event>
{
	private readonly IMongoDatabase db;
	private readonly IMongoCollection<Event> _eventsCollection;


	public EventRepository()
	{
		var client = new MongoClient("mongodb://localhost:27017");
		db = client.GetDatabase("gardamongodb");
		_eventsCollection = db.GetCollection<Event>("Events", new MongoCollectionSettings { AssignIdOnInsert = true });
	}

	public async Task<IEnumerable<Event>> GetAllEvents()
	{
		var results = await _eventsCollection.FindAsync(_ => true);
		return results.ToList();
	}

	public Task<Event?> GetEventById(Guid id)
	{
		var filter = Builders<Event>.Filter.Eq(e => e.Id, id);
		return _eventsCollection.Find(filter).FirstOrDefaultAsync();
	}

	public Task<Event?> GetEventByName(string name)
	{
		var filter = Builders<Event>.Filter.Eq(e => e.Name, name);
		return _eventsCollection.Find(filter).FirstOrDefaultAsync();
	}

	public async Task<IEnumerable<Event>> GetEventByType(Guid eventTypeId)
	{
		var filter = Builders<Event>.Filter.Eq(e => e.EventType.Id, eventTypeId );
		var result = await _eventsCollection.Find(filter).ToListAsync();
		return result;
	}

	public async Task<IEnumerable<Event>> GetEventByStatus(bool status)
	{
		var filter = Builders<Event>.Filter.Eq(e => e.IsUpcoming, status);
		var result = await _eventsCollection.Find(filter).ToListAsync();
		return result;
	}

	public Task AddEvent(Event newEvent)
	{
		return _eventsCollection.InsertOneAsync(newEvent);
	}

	public Task UpdateEvent(Event updateEvent)
	{
		var filter = Builders<Event>.Filter.Eq(e => e.Id, updateEvent.Id);
		return _eventsCollection.ReplaceOneAsync(filter, updateEvent);
	}

	public async Task RemoveEvent(Event eventToRemove)
	{
		var filter = Builders<Event>.Filter.Eq(e => e.Id, eventToRemove.Id);
		await _eventsCollection.DeleteOneAsync(filter);
	
	}
	
}