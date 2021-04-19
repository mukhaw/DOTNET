using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using MyWebApp.BLL.Implementation;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using NUnit.Framework;

namespace MyWebApp.BLL.Tests.Unit
{
    [TestFixture]
    public class OwnerServiceTest
    {
        [Test]
        public async Task ValidateAsync_OwnerExists_DoesNothing()
        {
            // Arrange
            var ownerContainer = new Mock<IOwnerContainer>();

            var owner= new Owner();
            var ownerDAL = new Mock<IOwnerDAL>();
            var ownerIdentity = new Mock<IOwnerIdentity>();
            ownerDAL.Setup(x => x.GetAsync(ownerIdentity.Object)).ReturnsAsync(owner);

            var ownerGetService = new OwnerService(ownerDAL.Object);
            
            // Act
            var action = new Func<Task>(() => ownerGetService.ValidateAsync(ownerContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_OwnerNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var ownerContainer = new Mock<IOwnerContainer>();
            ownerContainer.Setup(x => x.OwnerId).Returns(id);
            var ownerIdentity = new Mock<IOwnerIdentity>();
            var owner = new Owner();
            var ownerDAL = new Mock<IOwnerDAL>();
            ownerDAL.Setup(x => x.GetAsync(ownerIdentity.Object)).ReturnsAsync((Owner) null);

            var ownerGetService = new OwnerService(ownerDAL.Object);

            // Act
            var action = new Func<Task>(() => ownerGetService.ValidateAsync(ownerContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Owner not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_OwnerValidationSucceed_CreatesOwner()
        {
            // Arrange
            var owner = new OwnerUpdateModel();
            var expected = new Owner();

            var ownerDAL = new Mock<IOwnerDAL>();
            ownerDAL.Setup(x => x.InsertAsync(doctor)).ReturnsAsync(expected);

            var ownerService = new OwnerService(doctorDAL.Object);
            
            // Act
            var result = await ownerService.CreateAsync(owner);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}