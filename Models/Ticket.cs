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
