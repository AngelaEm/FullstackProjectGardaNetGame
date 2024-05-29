using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.Event.DomainToResponse;

public static class EventByIdMapper
{
    public static EventsResponse ToEventByIdResponse(this Shared.Entities.Event eventById)
    {
        var newEventTypeResponse = new EventTypesResponse
        {
            Id = eventById.EventType.Id,
            Type = eventById.EventType.Type
        };

        return new EventsResponse()
        {
            Id = eventById.Id,
            Name = eventById.Name,
            Location = eventById.Location,
            Date = eventById.Date,
            IsUpcoming = eventById.IsUpcoming,
            Description = eventById.Description,
            EventType = newEventTypeResponse,
            AgeRestriction = eventById.AgeRestriction,
            EventImageUrl = eventById.EventImageUrl,
            BackgroundImageUrl = eventById.BackgroundImageUrl,
            Price = eventById.Price,
            Capacity = eventById.Capacity,
            Duration = eventById.Duration,
        };
    }
}