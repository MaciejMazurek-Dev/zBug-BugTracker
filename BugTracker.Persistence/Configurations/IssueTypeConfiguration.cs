using BugTracker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugTracker.Persistence.Configurations
{
    public class IssueTypeConfiguration : IEntityTypeConfiguration<IssueType>
    {
        public void Configure(EntityTypeBuilder<IssueType> builder)
        {
            builder.Property("Name")
                .IsRequired()
                .HasMaxLength(20);

            builder.HasData(
                new IssueType
                {
                    Id = 1,
                    Name = "Bug",
                },
                new IssueType
                {
                    Id = 2,
                    Name = "Defect",
                },
                new IssueType
                {
                    Id = 3,
                    Name = "New feature",
                },
                new IssueType
                {
                    Id = 4,
                    Name = "Task",
                },
                new IssueType
                {
                    Id = 5,
                    Name = "Improvement",
                }
                );
        }
    }
}
