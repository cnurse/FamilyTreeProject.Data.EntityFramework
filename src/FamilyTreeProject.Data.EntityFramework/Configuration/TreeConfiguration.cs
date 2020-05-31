using FamilyTreeProject.Core;
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

            builder.Ignore(t => t.EntityType);
            builder.Ignore(t => t.HomeIndividualId);
            builder.Ignore(t => t.ImageId);
            builder.Ignore(t => t.LastViewedIndividualId);
            builder.Ignore(t => t.Multimedia);
            builder.Ignore(t => t.Notes);
        }
    }
}