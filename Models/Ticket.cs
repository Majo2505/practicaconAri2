using System;
using System.ComponentModel.DataAnnotations;
public class Ticket
{
    public Guid id { get; set; }
    public Guid MovieId { get; set; }

    [Required, StringLength(50)]
    public string BuyerName { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }

    [Required, Range(0, 100)]
    public float Price { get; set; }
}

public record CreateTicketDto
{
    public Guid MovieId { get; init; }

    [Required, StringLength(50)]
    public string BuyerName { get; init; } = string.Empty;
    public DateTime PurchaseDate { get; init; }

    [Required, Range(0, 100)]
    public float Price { get; init; }
}
