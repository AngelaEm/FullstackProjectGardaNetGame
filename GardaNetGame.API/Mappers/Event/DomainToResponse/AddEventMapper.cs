using GardaNetGame.Shared.DTOs.Events.Request;

namespace GardaNetGame.API.Mappers.Event.DomainToResponse
{
    public static class AddEventMapper
    {
        public static Shared.Entities.Event ToAddEvent(this AddEventRequest addEvent)
        {
            return new Shared.Entities.Event
            {
                Id = addEvent.Id,
                Name = addEvent.Name,
                Date = addEvent.Date,
                Location = addEvent.Location,
                IsUpcoming = addEvent.IsUpcoming,
                Description = addEvent.Description,
                EventType = addEvent.EventType,
                AgeRestriction = addEvent.AgeRestriction,
                EventImageUrl = addEvent.EventImageUrl,
                BackgroundImageUrl = addEvent.BackgroundImageUrl,
                Price = addEvent.Price,
                Capacity = addEvent.Capacity,
                Duration = addEvent.Duration,
            };
        }
    }
}
