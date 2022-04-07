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
                    Genre = "Romantic Comedy"
                }
            );
            context.SaveChanges();
        }
    }
}
