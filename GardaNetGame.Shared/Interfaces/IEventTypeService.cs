namespace GardaNetGame.Shared.Interfaces;

public interface IEventTypeService<T> where T : class
{
	Task<IEnumerable<T>> GetAllEventTypes();
	Task<T?> GetEventTypeById(Guid id);
	Task<T?> GetEventTypeByName(string name);
	Task AddEventType(T newEventType);
	Task UpdateEventType(T updateEventType);
	Task RemoveEventType(T eventTypeToRemove);
	
}

