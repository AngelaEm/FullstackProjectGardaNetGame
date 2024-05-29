using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.Event.DomainToResponse;

public static class GetEventByTypeMapper
{
    public static EventsResponse ToEventByTypeResponse(this Shared.Entities.Event eventByType)
    {
        var newEventTypeResponse = new EventTypesResponse
        {
            Id = eventByType.EventType.Id,
            Type = eventByType.EventType.Type
        };

        return new EventsResponse()
        {
            Id = eventByType.Id,
            Name = eventByType.Name,
            Location = eventByType.Location,
            Date = eventByType.Date,
            IsUpcoming = eventByType.IsUpcoming,
            Description = eventByType.Description,
            EventType = newEventTypeResponse,
            AgeRestriction = eventByType.AgeRestriction,
            EventImageUrl = eventByType.EventImageUrl,
            BackgroundImageUrl = eventByType.BackgroundImageUrl,
            Price = eventByType.Price,
            Capacity = eventByType.Capacity,
            Duration = eventByType.Duration,
        };
    }
}