using System;
using System.ComponentModel.DataAnnotations;
 


public class Movie
{
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

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
public record CreateMovieDto
{
    [Required]
    public string Title { get; init; } = string.Empty;

    [Required]
    public string Genre { get; init; } = string.Empty;

    [Required]
    public DateTime ReleaseDate { get; init; }

    [Required]
    public int DurationMinutes { get; init; }

    [Required]
    public bool Available { get; init; }
}

public record UpdateMovieDto
{
    [Required]
    public string Title { get; init; } = string.Empty;

    [Required]
    public string Genre { get; init; } = string.Empty;

    [Required]
    public DateTime ReleaseDate { get; init; }

    [Required]
    public int DurationMinutes { get; init; }

    [Required]
    public bool Available { get; init; }
}