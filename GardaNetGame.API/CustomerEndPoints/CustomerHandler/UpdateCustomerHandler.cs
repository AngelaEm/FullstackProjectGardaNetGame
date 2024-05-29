using FastEndpoints;
using GardaNetGame.API.Mappers.Customer.RequestToDomain;
using GardaNetGame.Shared.DTOs.Customer.Request;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.CustomerEndPoints.CustomerHandler;

public class UpdateCustomerHandler(ICustomerService<Customer> repo) : Endpoint<UpdateCustomerRequest, EmptyResponse>
{
	public override void Configure()
	{
		Put("/customers/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(UpdateCustomerRequest request, CancellationToken ct)
	{
        var customerEmailExist = await repo.GetCustomerByEmail(request.Email);
        if (customerEmailExist != null)
        {
            AddError(r => r.Email, $"A customer with the email: {request.Email} already exist");
            ThrowIfAnyErrors();
        }

        await repo.UpdateCustomer(request.ToUpdateCustomer());
		await SendOkAsync(new EmptyResponse(), ct);
	}
}