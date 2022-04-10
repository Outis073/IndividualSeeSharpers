namespace IndividualSeeSharpers.Models;

public class Ticket
{
    public int Id { get; set; }

    public int Seat { get; set; }

    public int Code { get; set; }

    public Price? Price { get; set; }

    public int OrderId { get; set; }

    public ICollection<Special>? Specials { get; set; }
}