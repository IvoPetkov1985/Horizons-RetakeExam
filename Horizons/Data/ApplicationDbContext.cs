using Horizons.Data.Configurations;
using Horizons.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Horizons.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Terrain> Terrains { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<UserDestination> UsersDestinations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IdentityUserConfiguration());
            builder.ApplyConfiguration(new UserDestinationConfiguration());
            builder.ApplyConfiguration(new TerrainConfiguration());
            builder.ApplyConfiguration(new DestinationConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
