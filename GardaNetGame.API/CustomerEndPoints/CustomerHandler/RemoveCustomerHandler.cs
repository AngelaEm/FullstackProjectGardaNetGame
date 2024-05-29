using FastEndpoints;
using GardaNetGame.Shared.DTOs;
using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;

namespace GardaNetGame.API.CustomerEndPoints.CustomerHandler;

public class RemoveCustomerHandler(ICustomerService<Customer> repo) : Endpoint<IdRequest, EmptyResponse>
{
	public override void Configure()
	{
		Delete("/customers/{id}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(IdRequest request, CancellationToken ct)
	{

		var customerToDelete = await repo.GetCustomerById(request.Id);

		if (customerToDelete is null)
		{
			await SendNotFoundAsync(ct);
			return;
		}

		await repo.DeleteCustomer(customerToDelete);
		await SendOkAsync(new EmptyResponse(), ct);

	}
}