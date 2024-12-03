using BugTracker.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTracker.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser
                {
                    Id = "7C85DDC9-5066-49D4-8D31-61C41D60414E",
                    UserName = "admin@example.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PasswordHash = "AQAAAAIAAYagAAAAEC/tlG1etbHRwF9Vi/xhaTlLtnOVA0O+SWvDP0cU+HOY8qIiQbnwcJ14ueFAGwgv9g==",
                    SecurityStamp = "ce907fd5-ccb4-4e96-a7ea-45712a14f5ef",
                    ConcurrencyStamp = "32fe9448-0c6c-43b2-b605-802c19c333a6"
                });
        }
    }
}
