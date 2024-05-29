using FastEndpoints;
using GardaNetGame.API.Mappers.Customer.DomainToResponse;
using GardaNetGame.Shared.DTOs.Customer.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.CustomerEndPoints.CustomerHandler;

public class GetAllCustomersHandler (ICustomerService<Customer> repo) : EndpointWithoutRequest
{
	public override void Configure()
	{
		Get("/customers");
		AllowAnonymous();
	}

	public async override Task HandleAsync(CancellationToken ct)
	{
		var customers = await repo.GetAllCustomers();

		var response = new GetAllCustomersListResponse()
		{
			Customers = customers.Select(c => c.ToCustomerResponse())
		};

		await SendOkAsync(response, ct);
	}
}