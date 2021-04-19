using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using MyWebApp.BLL.Contracts;
using MyWebApp.BLL.Implementation;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using NUnit.Framework;

namespace MyWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class CollectionServiceTest
    {
        [Test]
        public async Task ValidateAsync_CollectionExists_DoesNothing()
        {
            // Arrange
            var collectionContainer = new Mock<ICollectionContainer>();

            var collection = new Collection();
            var collectionDAL = new Mock<ICollectionDAL>();
            var collectionIdentity = new Mock<ICollectionIdentity>();
            collectionDAL.Setup(x => x.GetAsync(collectionIdentity.Object)).ReturnsAsync(street);

            var collectionGetService = new CollectionService(collectionDAL.Object);
            
            // Act
            var action = new Func<Task>(() => collectionGetService.ValidateAsync(collectionContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_CollectionNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var collectionContainer = new Mock<ICollectionContainer>();
            collectionContainer.Setup(x => x.CollectionId).Returns(id);
            var collectionIdentity = new Mock<ICollectionIdentity>();
            var collection = new Collection();
            var collectionDAL = new Mock<ICollectionDAL>();
            collectionDAL.Setup(x => x.GetAsync(collectionIdentity.Object)).ReturnsAsync((Collection) null);

            var collectionGetService = new CollectionService(collectionDAL.Object);

            // Act
            var action = new Func<Task>(() => collectionGetService.ValidateAsync(collectionContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Collection not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_CollectionValidationSucceed_CreatesCollection()
        {
            // Arrange
            var collection = new CollectionUpdateModel();
            var expected = new Collection();
            
            var collectionDAL = new Mock<ICollectionDAL>();
            collectionDAL.Setup(x => x.InsertAsync(collection)).ReturnsAsync(expected);

            var collectionService = new CollectionService(collectionDAL.Object);
            
            // Act
            var result = await collectionService.CreateAsync(collection);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}