using FamilyTreeProject.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class MultimediaLinkConfiguration : IEntityTypeConfiguration<MultimediaLink>
    {
        public void Configure(EntityTypeBuilder<MultimediaLink> builder)
        {
            builder.ToTable("MultimediaLinks");
            
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.TreeId);
            builder.Property(m => m.OwnerId);
            builder.Property(m => m.OwnerType);
            builder.Property(m => m.File);
            builder.Property(m => m.Format);
            builder.Property(m => m.Title);

            builder.Ignore(m => m.UniqueId);
            builder.Ignore(m => m.EntityType);
            builder.Ignore(m => m.Multimedia);
            builder.Ignore(m => m.Notes);
        }
    }
}
