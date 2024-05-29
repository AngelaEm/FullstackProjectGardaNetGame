namespace GardaNetGame.Shared.Interfaces;

public interface IEventService<T> where T : class
{
	Task<IEnumerable<T>> GetAllEvents();
	Task<T?> GetEventById(Guid id);
	Task<T?> GetEventByName(string name);
	Task<IEnumerable<T>> GetEventByType(Guid eventTypeId);
	Task<IEnumerable<T>> GetEventByStatus(bool status);
	Task AddEvent(T newEvent);
	Task UpdateEvent(T updateEvent);
	Task RemoveEvent(T eventToRemove);
}