using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using MongoDB.Driver;

namespace GardaNetGame.DataAccess.Repository;

public class EventTypeRepository : IEventTypeService<EventType>
{
	private readonly IMongoDatabase db;
	private readonly IMongoCollection<EventType> _eventTypesCollection;

	public EventTypeRepository()
	{
        var client = new MongoClient("mongodb://localhost:27017");
		db = client.GetDatabase("gardamongodb");
		_eventTypesCollection = db.GetCollection<EventType>("EventTypes", new MongoCollectionSettings { AssignIdOnInsert = true });
	}
	public async Task<IEnumerable<EventType>> GetAllEventTypes()
	{
		var results = await _eventTypesCollection.FindAsync(_ => true);
		return results.ToList();
	}

	public async Task<EventType?> GetEventTypeById(Guid id)
	{
		var filter = Builders<EventType>.Filter.Eq(e => e.Id, id);
		return await _eventTypesCollection.Find(filter).FirstOrDefaultAsync();
	}

	public async Task<EventType?> GetEventTypeByName(string name)
	{
		var filter = Builders<EventType>.Filter.Eq(e => e.Type, name);
		return await _eventTypesCollection.Find(filter).FirstOrDefaultAsync();
	}

	public Task AddEventType(EventType newEventType)
	{
		return _eventTypesCollection.InsertOneAsync(newEventType);
	}

	public Task UpdateEventType(EventType updateEventType)
	{
		var filter = Builders<EventType>.Filter.Eq(e => e.Id, updateEventType.Id);
		return _eventTypesCollection.ReplaceOneAsync(filter, updateEventType);
	}

	public async Task RemoveEventType(EventType eventTypeToRemove)
	{
		var filter = Builders<EventType>.Filter.Eq(e => e.Id, eventTypeToRemove.Id);
		await _eventTypesCollection.DeleteOneAsync(filter);
	}
}
