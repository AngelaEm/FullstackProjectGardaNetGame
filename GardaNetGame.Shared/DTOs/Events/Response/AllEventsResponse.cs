namespace GardaNetGame.Shared.DTOs.Events.Response;

public class AllEventsResponse
{
	public Guid EventId { get; set; }

	public string Name { get; set; }

	public DateTime Date { get; set; }

	public string Location { get; set; }

	public bool Status { get; set; }
}