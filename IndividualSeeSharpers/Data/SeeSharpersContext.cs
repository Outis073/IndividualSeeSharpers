#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualSeeSharpers.Data;
using Microsoft.EntityFrameworkCore;
using IndividualSeeSharpers.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SeeSharpersContext : IdentityDbContext<ApplicationUser>
    {
        public SeeSharpersContext (DbContextOptions<SeeSharpersContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }

    public DbSet<IndividualSeeSharpers.Models.Movie> Movie { get; set; }

    }

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        
    }
}
