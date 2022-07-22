using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class FactConfiguration : IEntityTypeConfiguration<Fact>
    {
        public void Configure(EntityTypeBuilder<Fact> builder)
        {
            builder.ToTable("Facts");
            
            builder.Property(ev => ev.Id).ValueGeneratedOnAdd();
            builder.Property(ev => ev.TreeId);
            builder.Property(ev => ev.OwnerId);
            builder.Property(ev => ev.OwnerType);
            builder.Property(ev => ev.FactType);
            builder.Property(ev => ev.Date);
            builder.Property(ev => ev.Place);
            builder.Property(ev => ev.UniqueId);

            builder.Ignore(ev => ev.EntityType);
            builder.Ignore(ev => ev.Citations);
            builder.Ignore(ev => ev.Multimedia);
            builder.Ignore(ev => ev.Notes);
        }
    }
}
