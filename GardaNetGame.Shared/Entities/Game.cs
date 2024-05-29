﻿namespace GardaNetGame.Shared.Entities;

public class Game
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public List<Genre>? Genre { get; set; } = new List<Genre>();

	public double Price { get; set; }

	public string Description { get; set; }

	public string? GameDeveloper { get; set; }

	public string? Publisher { get; set; }

	public DateTime PublicationDate { get; set; } 

	public string? Platform { get; set; }

	public int? AgeRestriction { get; set; }

	public string NumberOfPlayers { get; set; }

	public ICollection<string>? Reviews { get; set; } = new List<string>();

	public ICollection<double>? Grade { get; set; } = new List<double>();

	public string? SystemRequirement { get; set; }

	public string? OnlineFuntionality { get; set; }

	public string? ProductImageUrl { get; set; }

	public string? BackgroundImageUrl { get; set; }

	public string? VideoTrailer { get; set;}
}

