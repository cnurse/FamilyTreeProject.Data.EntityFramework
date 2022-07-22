using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.ToTable("Individuals");

            builder.Property(ind => ind.Id).ValueGeneratedOnAdd();
            builder.Property(ind => ind.TreeId);
            builder.Property(ind => ind.FirstName);
            builder.Property(ind => ind.LastName);
            builder.Property(ind => ind.Sex);
            builder.Property(ind => ind.FatherId);
            builder.Property(ind => ind.MotherId);

            builder.Ignore(ind => ind.EntityType);

            builder.Ignore(ind => ind.Name);
            builder.Ignore(ind => ind.Father);
            builder.Ignore(ind => ind.Mother);
            builder.Ignore(ind => ind.Children);
            builder.Ignore(ind => ind.Facts);
            builder.Ignore(ind => ind.Multimedia);
            builder.Ignore(ind => ind.Notes);

            builder.Ignore(ind => ind.Spouses);
            builder.Ignore(ind => ind.Citations);
        }
    }
}
