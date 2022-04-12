using IndividualSeeSharpers.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IndividualSeeSharpers.ViewModels;

public class ShowSelectionViewModel
{
    public Movie Movie { get; set; }
    public List<Show>? Shows { get; set; }
}