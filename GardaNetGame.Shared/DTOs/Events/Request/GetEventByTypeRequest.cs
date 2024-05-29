using GardaNetGame.Shared.Entities;

namespace GardaNetGame.Shared.DTOs.Events.Request;

public class GetEventByTypeRequest
{
    public EventType Type { get; set; }
}