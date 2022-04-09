using Microsoft.EntityFrameworkCore;

namespace IndividualSeeSharpers.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SeeSharpersContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<SeeSharpersContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    Duration = new TimeSpan(1, 36, 0),
                    Movie3d = false,
                    AgeRequirement = 12,
                    Thumbnail = "https://media.s-bol.com/822q0MkjXEGo/847x1200.jpg",
                    Language = "English",
                    Description = "Harry en Sally kennen elkaar al jaren en zijn erg goede vrienden, maar ze zijn bang dat seks de vriendschap zou verpesten.",
                    DescriptionEn = "Harry and Sally have known each other for years, and are very good friends, but they fear sex would ruin the friendship.",
                    Genre = "Romantische Komedie",
                    GenreEn = "Romantic Comedy"
                },

                new Movie
                {
                    Title = "Harry potter and the deadly hallows",
                    Duration = new TimeSpan(2, 32, 0),
                    Movie3d = false,
                    AgeRequirement = 6,
                    Thumbnail = "https://media.s-bol.com/qPrGlVlPgJr/550x730.jpg",
                    Language = "English",
                    Description = "Voldemort en zijn dienaren hebben het Ministerie van Toverkunst overgenomen. Harry slaat met zijn vrienden op de vlucht om de Gruzielementen te vernietigen.",
                    DescriptionEn = "As Harry, Ron, and Hermione race against time and evil to destroy the Horcruxes, they uncover the existence of the three most powerful objects in the wizarding world: the Deathly Hallows.",
                    Genre = "Fantasy",
                    GenreEn = "Fantasy"
                }
            );
            context.SaveChanges();
        }
    }
}
