using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.Shared.DTOs.Events.Response;

public class EventsResponse
{

	public Guid Id { get; set; }

	public string Name { get; set; }

	public DateTime Date { get; set; }

	public string Location { get; set; }

	public bool IsUpcoming { get; set; }

	public string Description { get; set; }

	public EventTypesResponse EventType { get; set; }

	public int? AgeRestriction { get; set; }

	public string? EventImageUrl { get; set; }

	public string? BackgroundImageUrl { get; set; }

	public virtual ICollection<string> AttendingCustomerEmails { get; set; } = new List<string>();

	public double Price { get; set; }

	public int Capacity { get; set; }

	public double Duration { get; set; }


}