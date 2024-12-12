using Horizons.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizons.Data.Configurations
{
    public class UserDestinationConfiguration : IEntityTypeConfiguration<UserDestination>
    {
        public void Configure(EntityTypeBuilder<UserDestination> builder)
        {
            builder.HasOne(ud => ud.Destination)
                .WithMany(d => d.UsersDestinations)
                .HasForeignKey(ud => ud.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
