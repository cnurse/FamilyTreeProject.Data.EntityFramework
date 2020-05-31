using FamilyTreeProject.Core.Common;
using FamilyTreeProject.Core.Contracts;
using FamilyTreeProject.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace FamilyTreeProject.Data.EntityFramework
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private FamilyTreeContext _db;

        public EFUnitOfWork(DbContextOptions<FamilyTreeContext> options)
        {
            Requires.NotNull(options);

            Initialize(new FamilyTreeContext(options));
        }

        public EFUnitOfWork(FamilyTreeContext db)
        {
            Requires.NotNull(db);

            Initialize(db);
        }

        private void Initialize(FamilyTreeContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : Entity
        {
            return new EFRepository<T>(_db);
        }
    }
}
