using IndividualSeeSharpers.Data;
using Microsoft.AspNetCore.Mvc;

namespace IndividualSeeSharpers.Models;

public class Review
{
    public int Id { get; set; }

    public ApplicationUser? User { get; set; }

    public string? Message { get; set; }

}