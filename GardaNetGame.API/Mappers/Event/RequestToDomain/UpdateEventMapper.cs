using GardaNetGame.Shared.DTOs.Events.Request;

namespace GardaNetGame.API.Mappers.Event.RequestToDomain;

public static class UpdateEventMapper
{
    public static Shared.Entities.Event ToEvent(this UpdateEventRequest request)
    {
        return new Shared.Entities.Event()
        {
            Id = request.Id,
            Name = request.Name,
            Location = request.Location,
            Date = request.Date,
            IsUpcoming = request.IsUpcoming,
            Description = request.Description,
            EventType = request.EventType,
            AgeRestriction = request.AgeRestriction,
            EventImageUrl = request.EventImageUrl,
            BackgroundImageUrl = request.BackgroundImageUrl,
            Price = request.Price,
            Capacity = request.Capacity,
            Duration = request.Duration,
        };
    }
}