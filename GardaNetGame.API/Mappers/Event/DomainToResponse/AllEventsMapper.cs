using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.Event.DomainToResponse;

public static class AllEventsMapper
{
    public static EventsResponse ToEventsResponse(this Shared.Entities.Event events)
    {
        var newEventTypeResponse = new EventTypesResponse
        {
            Id = events.EventType.Id,
            Type = events.EventType.Type
        };

        return new EventsResponse
        {
            Id = events.Id,
            Name = events.Name,
            Location = events.Location,
            Date = events.Date,
            IsUpcoming = events.IsUpcoming,
            Description = events.Description,
            EventType = newEventTypeResponse,
            AgeRestriction = events.AgeRestriction,
            EventImageUrl = events.EventImageUrl,
            BackgroundImageUrl = events.BackgroundImageUrl,
            Price = events.Price,
            Capacity = events.Capacity,
            Duration = events.Duration,

        };
    }
}

