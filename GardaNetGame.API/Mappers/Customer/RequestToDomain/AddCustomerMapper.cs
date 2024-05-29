using GardaNetGame.Shared.DTOs.Customer.Request;

namespace GardaNetGame.API.Mappers.Customer.RequestToDomain;

public static class AddCustomerMapper
{
    public static Shared.Entities.Customer ToAddCustomer(this AddCustomerRequest addCustomer)
    {
        return new Shared.Entities.Customer()
        {
            Id = addCustomer.Id,
            Email = addCustomer.Email,
            ListOfOrders = addCustomer.ListOfOrders
        };
    }
}