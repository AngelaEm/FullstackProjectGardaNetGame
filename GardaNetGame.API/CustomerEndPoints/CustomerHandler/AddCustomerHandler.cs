using FastEndpoints;
using GardaNetGame.API.Mappers.Customer.RequestToDomain;
using GardaNetGame.Shared.DTOs.Customer.Request;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.CustomerEndPoints.CustomerHandler;

public class AddCustomerHandler(ICustomerService<Customer> repo) : Endpoint<AddCustomerRequest, EmptyResponse>
{
	public override void Configure()
	{
		Post("customers");
		AllowAnonymous();
	}

	public override async Task HandleAsync(AddCustomerRequest request, CancellationToken ct)
    {
        var customerEmailExist = await repo.GetCustomerByEmail(request.Email);
        if (customerEmailExist != null)
        {
            AddError(r => r.Email, $"A customer with the email: {request.Email} already exist");
            ThrowIfAnyErrors();
        }
		var addCustomer = request.ToAddCustomer();
		await repo.AddCustomer(addCustomer);
		await SendOkAsync(new EmptyResponse());
	}
}