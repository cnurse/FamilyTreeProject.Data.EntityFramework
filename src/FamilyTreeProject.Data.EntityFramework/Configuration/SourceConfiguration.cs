using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class SourceConfiguration : IEntityTypeConfiguration<Source>
    {
        public void Configure(EntityTypeBuilder<Source> builder)
        {
            builder.ToTable("Sources");

            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.TreeId);
            builder.Property(s => s.RepositoryId);
            builder.Property(s => s.Title);
            builder.Property(s => s.Author);
            builder.Property(s => s.Publisher);

            builder.Ignore(s => s.EntityType);
            builder.Ignore(s => s.Multimedia);
            builder.Ignore(s => s.Notes);
            builder.Ignore(s => s.Repository);
        }
    }
}
