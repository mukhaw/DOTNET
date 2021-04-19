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
    public class ByerServiceTest
    {
        [Test]
        public async Task ValidateAsync_ByerExists_DoesNothing()
        {
            // Arrange
            var ByerContainer = new Mock<IByerContainer>();

            var byer= new Byer();
            var byerService = new Mock<IByerService>();
            var byerDAL = new Mock<IByerDAL>();
            var byerIdentity = new Mock<IByerIdentity>();
            byerDAL.Setup(x => x.GetAsync(byerIdentity.Object)).ReturnsAsync(byer);

            var byerGetService = new ByerService(byerDAL.Object,pictureService.Object);
            
            // Act
            var action = new Func<Task>(() => byerGetService.ValidateAsync(byerContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_ByerNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var byerContainer = new Mock<IByerContainer>();
            byerContainer.Setup(x => x.ByerId).Returns(id);
            var byerIdentity = new Mock<IByerIdentity>();
            var byerService = new Mock<IByerService>();
            var byer = new Byer();
            var byerDAL = new Mock<IByerDAL>();
            byerDAL.Setup(x => x.GetAsync(byerIdentity.Object)).ReturnsAsync((Byer) null);

            var byerGetService = new ByerService(byerDAL.Object,pictureService.Object);

            // Act
            var action = new Func<Task>(() => byerGetService.ValidateAsync(byerContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Byer not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_ByerValidationSucceed_CreatesPatient()
        {
            // Arrange
            var byer = new ByerUpdateModel();
            var expected = new Byer();
            
            var pictureService = new Mock<IPictureService>();
            pictureService.Setup(x => x.ValidateAsync(patient));

            var byerDAL = new Mock<IByerDAL>();
            byerDAL.Setup(x => x.InsertAsync(byer)).ReturnsAsync(expected);

            var byerService = new ByerService(byerDAL.Object, pictureService.Object);
            
            // Act
            var result = await byerService.CreateAsync(byer);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_ByerValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var byer = new ByerUpdateModel();
            var expected = fixture.Create<string>();
            
            var pictureService = new Mock<IPictureService>();
            pictureService
                .Setup(x => x.ValidateAsync(byer))
                .Throws(new InvalidOperationException(expected));
            
            var byerDAL = new Mock<IByerDAL>();
            
            var byerService = new ByerService(byerDAL.Object, pictureService.Object);
            
            var action = new Func<Task>(() => byerService.CreateAsync(byer));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            byerDAL.Verify(x => x.InsertAsync(byer), Times.Never);
        }
    }
}