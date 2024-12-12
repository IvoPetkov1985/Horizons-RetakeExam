using Horizons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizons.Data.Configurations
{
    public class TerrainConfiguration : IEntityTypeConfiguration<Terrain>
    {
        public void Configure(EntityTypeBuilder<Terrain> builder)
        {
            builder.HasData(
                new Terrain { Id = 1, Name = "Mountain" },
                new Terrain { Id = 2, Name = "Beach" },
                new Terrain { Id = 3, Name = "Forest" },
                new Terrain { Id = 4, Name = "Plain" },
                new Terrain { Id = 5, Name = "Urban" },
                new Terrain { Id = 6, Name = "Village" },
                new Terrain { Id = 7, Name = "Cave" },
                new Terrain { Id = 8, Name = "Canyon" });
        }
    }
}
