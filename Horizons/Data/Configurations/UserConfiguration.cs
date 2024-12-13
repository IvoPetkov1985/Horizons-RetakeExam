using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizons.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            IdentityUser defaultUser = new()
            {
                Id = "7699db7d-964f-4782-8209-d76562e0fece",
                UserName = "admin@horizons.com",
                NormalizedUserName = "ADMIN@HORIZONS.COM",
                Email = "admin@horizons.com",
                NormalizedEmail = "ADMIN@HORIZONS.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                    new IdentityUser { UserName = "admin@horizons.com" },
                    "Admin123!")
            };

            builder.HasData(defaultUser);
        }
    }
}
