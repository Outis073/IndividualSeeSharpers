namespace IndividualSeeSharpers.Models;

public class Special
{
    public int Id { get; set; }
    public String? Name { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public Decimal Cost { get; set; }
    public String? Description { get; set; }
    public String? DescriptionEn { get; set; }
}