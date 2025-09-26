using System;
using System.ComponentModel.DataAnnotations;
 


public class Movie
{
    public Guid Id { get; set; }

    [Required]
    public string title { get; set; } = string.Empty;

    [Required]
    public string Genre { get; set; } = string.Empty;

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public int DurationMinutes { get; set; }

    [Required]
    public bool Available { get; set; }
}

//Dtos
public record CreateMovie
{
    [Required]
    public string title { get; init; } = string.Empty;

    [Required]
    public string genre { get; init; } = string.Empty;

    [Required]
    public DateTime ReleaseDate { get; init; }

    [Required]
    public int DurationMinutes { get; init; }

    [Required]
    public bool Available { get; init; }
}

public record UpdateMovie
{
    [Required]
    public string title { get; init; } = string.Empty;

    [Required]
    public string genre { get; init; } = string.Empty;

    [Required]
    public DateTime ReleaseDate { get; init; }

    [Required]
    public int DurationMinutes { get; init; }

    [Required]
    public bool Available { get; init; }
}