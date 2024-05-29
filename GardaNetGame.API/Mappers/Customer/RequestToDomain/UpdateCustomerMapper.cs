using GardaNetGame.Shared.DTOs.Customer.Request;

namespace GardaNetGame.API.Mappers.Customer.RequestToDomain;

public static class UpdateCustomerMapper
{
	public static Shared.Entities.Customer ToUpdateCustomer(this UpdateCustomerRequest updateCustomer)
	{
		return new Shared.Entities.Customer()
		{
			Id = updateCustomer.Id,
			Email = updateCustomer.Email,
			ListOfOrders = updateCustomer.ListOfOrders
		};
	}
}