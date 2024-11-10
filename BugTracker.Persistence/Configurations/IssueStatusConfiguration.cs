using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTracker.Persistence.Configurations
{
    public class IssueStatusConfiguration : IEntityTypeConfiguration<IssueStatus>
    {
        public void Configure(EntityTypeBuilder<IssueStatus> builder)
        {
            builder.Property("Name")
                .IsRequired()
                .HasMaxLength(20);

            builder.HasData(
                new IssueStatus
                {
                    Id = 1,
                    Name = "New"
                },
                new IssueStatus
                {
                    Id = 2,
                    Name = "Assigned"
                },
                new IssueStatus
                {
                    Id = 3,
                    Name = "In progress"
                },
                new IssueStatus
                {
                    Id = 4,
                    Name = "Resolved"
                },
                new IssueStatus
                {
                    Id = 5,
                    Name = "Closed"
                }
                );
        }
    }
}
