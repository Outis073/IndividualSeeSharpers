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
                },
                
                
                new Movie
                {
                    Title = "The Northman",
                    Duration = new TimeSpan(2, 20, 0),
                    Movie3d = false,
                    AgeRequirement = 12,
                    Thumbnail = "https://www.vuecinemas.nl/thumb?w=268&f=jpg&src=userfiles/image/movies/2039522_147051.jpg&alt=img/movie_placeholder.png",
                    Language = "English",
                    Description = "The Northman, de nieuwe film van de visionaire regisseur Robert Eggers (The Lighthouse, The Witch), is een heroïsch actie-epos over een jonge Vikingprins en zijn missie om de moord op zijn vader te wreken. De sterrencast bestaat onder meer uit Alexander Skarsgård, Nicole Kidman, Claes Bang, Anya Taylor-Joy, Ethan Hawke, Björk en Willem Dafoe.",
                    DescriptionEn = "The Northman, the new film from visionary director Robert Eggers (The Lighthouse, The Witch), is a heroic action epic about a young Viking prince and his mission to avenge his father's murder. The star cast includes Alexander Skarsgård, Nicole Kidman, Claes Bang, Anya Taylor-Joy, Ethan Hawke, Björk and Willem Dafoe.",
                    Genre = "Actie/Avontuur",
                    GenreEn = "Action/Adventure"
                }
            );
            context.SaveChanges();


        }


}
}

