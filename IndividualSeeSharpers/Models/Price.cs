using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualSeeSharpers.Models;

public class Price
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public Decimal PriceAmount { get; set; }
}