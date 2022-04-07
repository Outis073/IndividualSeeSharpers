using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IndividualSeeSharpers.Models;

public static class SeedRoles
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SeeSharpersContext(serviceProvider.GetRequiredService<DbContextOptions<SeeSharpersContext>>()))
        {
            string[] roles = new string[] { "Admin", "BackOffice", "Cashier", "Customer" };

            var newrolelist = new List<IdentityRole>();
            foreach (string role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role))
                {
                    newrolelist.Add(new IdentityRole(role));
                }
            }
            context.Roles.AddRange(newrolelist);
            context.SaveChanges();
        }
    }
}