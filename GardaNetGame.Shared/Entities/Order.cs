namespace GardaNetGame.Shared.Entities;

public class Order
{
	public Guid Id { get; set; }

	public List<Event>? Events { get; set; } = new List<Event>(); 
    
    public List<Game>? Games { get; set; } = new List<Game>();

    public bool IsActive { get; set; } = true;
}