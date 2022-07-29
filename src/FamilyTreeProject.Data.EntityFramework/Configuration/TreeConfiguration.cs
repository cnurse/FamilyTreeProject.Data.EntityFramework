using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class TreeConfiguration : IEntityTypeConfiguration<Tree>
    {
        public void Configure(EntityTypeBuilder<Tree> builder)
        {
            builder.ToTable("Trees");

            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Property(t => t.Description);
            builder.Property(t => t.Name);
            builder.Property(t => t.OwnerId);
            builder.Property(t => t.Title);
            builder.Property(t => t.UniqueId);
            builder.Property(t => t.HomeIndividualId);
            builder.Property(t => t.ImageId);
            builder.Property(t => t.LastViewedIndividualId);

            builder.Ignore(t => t.EntityType);
            builder.Ignore(t => t.Multimedia);
            builder.Ignore(t => t.Notes);
        }
    }
}