using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using MongoDB.Driver;

namespace GardaNetGame.DataAccess.Repository;

public class CustomerRepository : ICustomerService<Customer>
{
	private readonly IMongoDatabase db;
	private readonly IMongoCollection<Customer> _customerCollection;

	public CustomerRepository()
	{
        var client = new MongoClient("mongodb://localhost:27017");
		db = client.GetDatabase("gardamongodb");
		_customerCollection =
			db.GetCollection<Customer>("Customers", new MongoCollectionSettings { AssignIdOnInsert = false });
	}

	public async Task<IEnumerable<Customer>> GetAllCustomers()
	{
		var allCustomers = await _customerCollection.FindAsync(_ => true);
		return allCustomers.ToList();
	}

	public async Task<Customer?> GetCustomerById(Guid id)
	{
		var filter = Builders<Customer>.Filter.Eq(g => g.Id, id);
		var customerWithId = await _customerCollection.Find(filter).FirstOrDefaultAsync();
		return customerWithId;
	}

	public async Task<Customer> GetCustomerByEmail(string email)
	{
		var filter = Builders<Customer>.Filter.Eq(c => c.Email, email);
		var customerWithEmail = await _customerCollection.Find(filter).FirstOrDefaultAsync();
		return customerWithEmail;
	}

	public Task AddCustomer(Customer customer)
	{
		return _customerCollection.InsertOneAsync(customer);
	}

	public Task UpdateCustomer(Customer customer)
	{
		var filter = Builders<Customer>.Filter.Eq(c => c.Id, customer.Id);
		return _customerCollection.ReplaceOneAsync(filter, customer);
	}

	public async Task DeleteCustomer(Customer customer)
	{
		var filter = Builders<Customer>.Filter.Eq(c => c.Id, customer.Id);
		await _customerCollection.DeleteOneAsync(filter);
	}
}