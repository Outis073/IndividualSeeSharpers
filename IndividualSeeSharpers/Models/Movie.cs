using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualSeeSharpers.Models;


public class Movie
{
    public int Id { get; set; }
    public String? Title { get; set; }
    public TimeSpan Duration { get; set; }
    public Boolean Movie3d { get; set; }
    public DateTime BeginTime { get; set; }
    public Int16? AgeRequirement { get; set; }
    public String? Thumbnail { get; set; }
    public String? Language { get; set; }

    [DisplayName("Beschrijving")]
    public String? Description { get; set; }

    [DisplayName("Description")]
    public String? DescriptionEn { get; set; } 
    public String? Genre { get; set; }
    public String? GenreEn { get; set; }
    public ICollection<Show>? Viewings { get; set; }
}