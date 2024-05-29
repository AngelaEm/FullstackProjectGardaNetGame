using GardaNetGame.Shared.Entities;

namespace GardaNetGame.Shared.DTOs.Events.Request
{
    public class AddEventRequest
    {
        public Guid Id { get; set; } = new Guid();

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public bool IsUpcoming { get; set; }

        public string Description { get; set; }

        public EventType EventType { get; set; }

        public int AgeRestriction { get; set; }

        public string EventImageUrl { get; set; }

        public string BackgroundImageUrl { get; set; }

        public virtual ICollection<string> AttendingCustomerEmails { get; set; } = new List<string>();

        public double Price { get; set; }

        public int Capacity { get; set; }

        public double Duration { get; set; }
    }
}
