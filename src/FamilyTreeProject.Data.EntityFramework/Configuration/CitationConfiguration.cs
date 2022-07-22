using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class CitationConfiguration : IEntityTypeConfiguration<Citation>
    {
        public void Configure(EntityTypeBuilder<Citation> builder)
        {
            builder.ToTable("Citations");
            
            builder.Property(cit => cit.Id).ValueGeneratedOnAdd();
            builder.Property(cit => cit.TreeId);
            builder.Property(cit => cit.SourceId);
            builder.Property(cit => cit.OwnerId);
            builder.Property(cit => cit.OwnerType);
            builder.Property(cit => cit.Date);
            builder.Property(cit => cit.Page);
            builder.Property(cit => cit.Text);
            builder.Property(cit => cit.UniqueId);

            builder.Ignore(cit => cit.Source);
            builder.Ignore(cit => cit.EntityType);
            builder.Ignore(cit => cit.Multimedia);
            builder.Ignore(cit => cit.Notes);
        }
    }
}
