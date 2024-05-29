using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using MongoDB.Driver;

namespace GardaNetGame.DataAccess.Repository;

public class OrderRepository : IOrderService<Order>
{
    private readonly IMongoDatabase db;
    private readonly IMongoCollection<Order> _ordersCollection;
    private readonly IMongoCollection<Event> _eventsCollection;
    private readonly IMongoCollection<Game> _gamesCollection;


    public OrderRepository()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        db = client.GetDatabase("gardamongodb");
        _ordersCollection = db.GetCollection<Order>("Orders", new MongoCollectionSettings { AssignIdOnInsert = true });
        _eventsCollection = db.GetCollection<Event>("Events", new MongoCollectionSettings { AssignIdOnInsert = true });
        _gamesCollection = db.GetCollection<Game>("Games", new MongoCollectionSettings { AssignIdOnInsert = true });
    }

    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        var result = await _ordersCollection.FindAsync(_ => true);
        return result.ToList();
    }

    public async Task<Order?> GetOrderById(Guid id)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, id);
        return await _ordersCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Order> AddOrder(Order newOrder)
    {

        await _ordersCollection.InsertOneAsync(newOrder);

        var filter = Builders<Order>.Filter.Eq(o => o.Id, newOrder.Id);
        return await _ordersCollection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task AddEventToOrder(Guid orderId, Guid eventId, HttpContent content)
    {
        var filterOrder = Builders<Order>.Filter.Eq(o => o.Id, orderId);
        var filterEvent = Builders<Event>.Filter.Eq(e => e.Id, eventId);
        var eventToAdd = await _eventsCollection.Find(filterEvent).FirstOrDefaultAsync();

        var update = Builders<Order>.Update.AddToSet(f => f.Events, eventToAdd);
        await _ordersCollection.UpdateOneAsync(filterOrder, update);
    }

    public async Task AddGameToOrder(Guid orderId, Guid gameId)
    {
        var filterOrder = Builders<Order>.Filter.Eq(o => o.Id, orderId);
        var filterGame = Builders<Game>.Filter.Eq(e => e.Id, gameId);
        var gameToAdd = await _gamesCollection.Find(filterGame).FirstOrDefaultAsync();

        var update = Builders<Order>.Update.AddToSet(f => f.Games, gameToAdd);
        await _ordersCollection.UpdateOneAsync(filterOrder, update);
    }

    public Task UpdateOrder(Order updateOrder)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, updateOrder.Id);
        return _ordersCollection.ReplaceOneAsync(filter, updateOrder);
    }

    public Task RemoveOrder(Order orderToRemove)
    {
        var filter = Builders<Order>.Filter.Eq(o => o.Id, orderToRemove.Id);
        return _ordersCollection.DeleteOneAsync(filter);
    }

    public async Task RemoveEventFromOrder(Guid orderId, Guid eventId)
    {
        var filterOrder = Builders<Order>.Filter.Eq(o => o.Id, orderId);

        var update = Builders<Order>.Update.PullFilter(o => o.Events, e => e.Id == eventId);

        await _ordersCollection.UpdateOneAsync(filterOrder, update);
    }

    public async Task RemoveGameFromOrder(Guid orderId, Guid gameId)
    {
        var filterOrder = Builders<Order>.Filter.Eq(o => o.Id, orderId);

        var update = Builders<Order>.Update.PullFilter(o => o.Games, g => g.Id == gameId);

        await _ordersCollection.UpdateOneAsync(filterOrder, update);
    }

    public async Task<Order?> GetOrderIfActive()
    {
        var filter = Builders<Order>.Filter.Eq(o => o.IsActive, true);
        return await _ordersCollection.Find(filter).FirstOrDefaultAsync();
    }
}