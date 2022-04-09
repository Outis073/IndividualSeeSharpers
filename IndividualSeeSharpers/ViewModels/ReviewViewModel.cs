using IndividualSeeSharpers.Data;
using IndividualSeeSharpers.Models;

namespace IndividualSeeSharpers.ViewModels;

public class ReviewViewModel
{
    public Review? Review { get; set; }

    public ApplicationUser? User { get; set; }
}