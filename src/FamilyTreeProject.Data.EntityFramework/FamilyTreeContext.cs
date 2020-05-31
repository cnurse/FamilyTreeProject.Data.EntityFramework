using FamilyTreeProject.Data.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeProject.Data.EntityFramework
{
    public class FamilyTreeContext : DbContext
    {
        public FamilyTreeContext() { }

        public FamilyTreeContext(DbContextOptions<FamilyTreeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TreeConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new IndividualConfiguration());
            modelBuilder.ApplyConfiguration(new CitationConfiguration());
            modelBuilder.ApplyConfiguration(new FactConfiguration());
            modelBuilder.ApplyConfiguration(new MultimediaLinkConfiguration());
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new RepositoryConfiguration());
            modelBuilder.ApplyConfiguration(new SourceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}