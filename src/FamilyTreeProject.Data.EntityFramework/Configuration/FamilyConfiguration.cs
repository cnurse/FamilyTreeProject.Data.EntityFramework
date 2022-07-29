using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.ToTable("Families");
            
            builder.Property(fam => fam.Id).ValueGeneratedOnAdd();
            builder.Property(fam => fam.TreeId);
            builder.Property(fam => fam.HusbandId);
            builder.Property(fam => fam.WifeId);
            builder.Property(fam => fam.UniqueId);

            builder.Ignore(fam => fam.EntityType);
            builder.Ignore(fam => fam.Children);
            builder.Ignore(fam => fam.Husband);
            builder.Ignore(fam => fam.Wife);
            builder.Ignore(fam => fam.Facts);
            builder.Ignore(fam => fam.Multimedia);
            builder.Ignore(fam => fam.Notes);
            builder.Ignore(fam => fam.Citations);
        }
    }
}
