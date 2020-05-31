using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FamilyTreeProject.Data.EntityFramework.Tests.Common
{
    public class EFAssert
    {
        public static void RowCount<TEntity>(DbContextOptions<FamilyTreeContext> options, int expectedCount) where TEntity : class
        {
            //Use Different Instance of context to verify database update
            using (var context = new FamilyTreeContext(options))
            {
                Assert.AreEqual(expectedCount, context.Set<TEntity>().Count());
            }
        }
    }
}