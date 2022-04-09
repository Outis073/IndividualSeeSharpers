using IndividualSeeSharpers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IndividualSeeSharpers.ViewModels;

public class HomeIndexViewModel
{
    public Movie? Movie { get; set; }
    public Show? Viewing { get; set; }
}