using FastEndpoints;
using GardaNetGame.API.Mappers.Customer.DomainToResponse;
using GardaNetGame.Shared.DTOs.Customer.Request;
using GardaNetGame.Shared.DTOs.Customer.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.CustomerEndPoints.CustomerHandler;

public class GetCustomerByEmailHandler (ICustomerService<Customer> repo) : Endpoint<GetCustomerByEmailRequest, CustomerByEmailResponse>
{
	public override void Configure()
	{
		Get("/customers/email/{email}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(GetCustomerByEmailRequest request, CancellationToken ct)
	{
		var customerByEmail = await repo.GetCustomerByEmail(request.Email);

		if (customerByEmail is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await SendOkAsync(customerByEmail.ToCustomerByEmailResponse(), ct);


	}
}