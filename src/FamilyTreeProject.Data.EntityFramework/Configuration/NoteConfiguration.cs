using FamilyTreeProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamilyTreeProject.Data.EntityFramework.Configuration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
            builder.Property(n => n.TreeId);
            builder.Property(n => n.OwnerId);
            builder.Property(n => n.OwnerType);
            builder.Property(n => n.Text);

            builder.Ignore(n => n.UniqueId);
            builder.Ignore(n => n.EntityType);
            builder.Ignore(n => n.Multimedia);
            builder.Ignore(n => n.Notes);
        }
    }
}
