using System.ComponentModel.DataAnnotations;

namespace IndividualSeeSharpers.Models;

public class Subscriber
{
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    public String? Email { get; set; }
}