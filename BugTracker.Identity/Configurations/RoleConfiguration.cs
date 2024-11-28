using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTracker.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "bec2f559-0e72-4476-be34-d0425ccf889f",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = "e2b35cdc-f9b2-42a4-83c5-940b35c4193d",
                    Name = "Developer",
                    NormalizedName = "DEVELOPER"
                },
                new IdentityRole
                {
                    Id = "e964397b-012e-428c-8d9e-cca5aa85d8e6",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
        }
    }
}
