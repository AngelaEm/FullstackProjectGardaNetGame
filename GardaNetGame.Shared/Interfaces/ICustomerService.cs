namespace GardaNetGame.Shared.Interfaces;

public interface ICustomerService<T> where T : class
{
	Task<IEnumerable<T>> GetAllCustomers();

	Task<T?> GetCustomerById(Guid id);

	Task<T> GetCustomerByEmail(string email);

	Task AddCustomer (T customer);

	Task UpdateCustomer (T customer);

	Task DeleteCustomer (T customer);
}