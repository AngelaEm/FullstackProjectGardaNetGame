namespace GardaNetGame.Shared.Interfaces;

public interface IOrderService<T> where T : class
{
	Task<IEnumerable<T>> GetAllOrders();
	Task<T?> GetOrderById(Guid id);
	Task<T?> AddOrder(T newOrder);

	Task AddEventToOrder(Guid orderId, Guid eventId, HttpContent content);
	Task AddGameToOrder(Guid orderId, Guid gameId);
    Task UpdateOrder(T updateOrder);
	Task RemoveOrder(T orderToRemove);

    Task RemoveEventFromOrder(Guid orderId, Guid eventId);
    Task RemoveGameFromOrder(Guid orderId, Guid gameId);
    Task<T?> GetOrderIfActive();
}