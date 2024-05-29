using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.Event.DomainToResponse;

public static class EventByStatusMapper
{
    public static EventsResponse ToEventByStatusResponse(this Shared.Entities.Event eventByStatus)
    {
        var newEventTypeResponse = new EventTypesResponse
        {
            Id = eventByStatus.EventType.Id,
            Type = eventByStatus.EventType.Type
        };

        return new EventsResponse
        {
            Id = eventByStatus.Id,
            Name = eventByStatus.Name,
            Location = eventByStatus.Location,
            Date = eventByStatus.Date,
            IsUpcoming = eventByStatus.IsUpcoming,
            Description = eventByStatus.Description,
            EventType = newEventTypeResponse,
            AgeRestriction = eventByStatus.AgeRestriction,
            EventImageUrl = eventByStatus.EventImageUrl,
            BackgroundImageUrl = eventByStatus.BackgroundImageUrl,
            Price = eventByStatus.Price,
            Capacity = eventByStatus.Capacity,
            Duration = eventByStatus.Duration,

        };
    }
}