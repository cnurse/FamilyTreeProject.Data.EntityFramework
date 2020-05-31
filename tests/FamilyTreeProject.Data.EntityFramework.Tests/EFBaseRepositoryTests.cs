using System;
using FamilyTreeProject.Core.Common;
using FamilyTreeProject.Data.EntityFramework.Tests.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FamilyTreeProject.Data.EntityFramework.Tests
{
    public abstract class EFBaseRepositoryTests<T> where T : Entity, new()
    {
        [Test]
        public void Constructor_Throws_On_Null_Database()
        {
            //Arrange
            FamilyTreeContext database = null;

            //Act

            //Assert
            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new EFRepository<T>(database));
        }

        [Test]
        public void Add_Throws_On_Null_Entity()
        {
            //Arrange
            var mockContext = new Mock<FamilyTreeContext>();
            var rep = new EFRepository<T>(mockContext.Object);

            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => rep.Add(null));
        }
        
        [Test]
        public void Add_Writes_To_Database_With_Call_To_Context_SaveChanges()
        {
            //Arrange
            var options = GetContextOptions("Add_Writes_To_Database_With_Call_To_Context_SaveChanges");
            var entity = new T();

            //Act
            using(var context =  new FamilyTreeContext(options))
            {
                var rep = new EFRepository<T>(context);
                rep.Add(entity);
                context.SaveChanges();
            }

            //Assert
            EFAssert.RowCount<T>(options, 1);
        }

        [Test]
        public void Add_Writes_To_Database_When_Using_UnitOfWork_With_Call_To_Commit()
        {
            //Arrange
            var options = GetContextOptions("Add_Writes_To_Database_When_Using_UnitOfWork_With_Call_To_Commit");
            var entity = new T();

            //Act
            using(var unitOfWork =  new EFUnitOfWork(new FamilyTreeContext(options)))
            {
                var rep = unitOfWork.GetRepository<T>();
                rep.Add(entity);
                unitOfWork.Commit();
            }

            //Assert
            EFAssert.RowCount<T>(options, 1);
        }
        
        [Test]
        public void Add_Fails_To_Write_To_Database_When_Using_UnitOfWork_Without_Call_To_Commit()
        {
            //Arrange
            var options = GetContextOptions("Add_Fails_To_Write_To_Database_When_Using_UnitOfWork_Without_Call_To_Commit");
            var entity = new T();

            //Act
            using(var unitOfWork =  new EFUnitOfWork(new FamilyTreeContext(options)))
            {
                var rep = unitOfWork.GetRepository<T>();
                rep.Add(entity);
            }

            //Assert
            EFAssert.RowCount<T>(options, 0);
        }

        [Test]
        public void Add_Fails_To_Write_To_Database_Without_Call_To_Context_SaveChanges()
        {
            //Arrange
            var options = GetContextOptions("Add_Fails_To_Write_To_Database_Without_Call_To_Context_SaveChanges");
            var entity = new T();

            //Act
            using(var context =  new FamilyTreeContext(options))
            {
                var rep = new EFRepository<T>(context);
                rep.Add(entity);
            }

            //Assert
            EFAssert.RowCount<T>(options, 0);
        }
        
        [Test]
        public void Delete_Throws_On_Null_Entity()
        {
            //Arrange
            var mockContext = new Mock<FamilyTreeContext>();
            var rep = new EFRepository<T>(mockContext.Object);

            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => rep.Delete(null));
        }
        
        [Test]
        public void Update_Throws_On_Null_Entity()
        {
            //Arrange
            var mockContext = new Mock<FamilyTreeContext>();
            var rep = new EFRepository<T>(mockContext.Object);

            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => rep.Update(null));
        }

        protected DbContextOptions<FamilyTreeContext> GetContextOptions(string databaseName)
        {
            var options = new DbContextOptionsBuilder<FamilyTreeContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
            return options;
        }
    }
}