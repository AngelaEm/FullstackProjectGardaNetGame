using GardaNetGame.Shared.DTOs.Events.Response;
using GardaNetGame.Shared.DTOs.EventTypes.Response;

namespace GardaNetGame.API.Mappers.Event.DomainToResponse;

public static class EventByNameMapper
{
    public static EventsResponse ToEventByNameResponse(this Shared.Entities.Event eventByName)
    {
        var newEventTypeResponse = new EventTypesResponse
        {
            Id = eventByName.EventType.Id,
            Type = eventByName.EventType.Type
        };

        return new EventsResponse()
        {
            Id = eventByName.Id,
            Name = eventByName.Name,
            Location = eventByName.Location,
            Date = eventByName.Date,
            IsUpcoming = eventByName.IsUpcoming,
            Description = eventByName.Description,
            EventType = newEventTypeResponse,
            AgeRestriction = eventByName.AgeRestriction,
            EventImageUrl = eventByName.EventImageUrl,
            BackgroundImageUrl = eventByName.BackgroundImageUrl,
            Price = eventByName.Price,
            Capacity = eventByName.Capacity,
            Duration = eventByName.Duration,
        };
    }
}