using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class RepositoryConfiguration : IEntityTypeConfiguration<Repository>
    {
        public void Configure(EntityTypeBuilder<Repository> builder)
        {
            builder.ToTable("Repositories");
            
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.TreeId);
            builder.Property(r => r.UniqueId);
            builder.Property(r => r.Name);
            builder.Property(r => r.Address);

            builder.Ignore(r => r.EntityType);
            builder.Ignore(r => r.Multimedia);
            builder.Ignore(r => r.Notes);
        }
    }
}
