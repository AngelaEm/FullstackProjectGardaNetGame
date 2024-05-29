using FastEndpoints;
using GardaNetGame.API.Mappers.Customer.DomainToResponse;
using GardaNetGame.Shared.DTOs.Customer.Request;
using GardaNetGame.Shared.DTOs.Customer.Response;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.CustomerEndPoints.CustomerHandler;

public class GetCustomerByIdHandler (ICustomerService<Customer> repo) : Endpoint<GetCustomerByIdRequest, CustomerByIdResponse>
{
	public override void Configure()
	{
		Get("/customers/id/{id}");
		AllowAnonymous();
	}

	public async override Task HandleAsync(GetCustomerByIdRequest request, CancellationToken ct)
	{
		var customerById = await repo.GetCustomerById(request.Id);

		if (customerById is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await SendOkAsync(customerById.ToCustomerByIdResponse(), ct);
	}
}