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
    public class PictureServiceTest
    {
        [Test]
        public async Task ValidateAsync_PictureExists_DoesNothing()
        {
            // Arrange
            var pictureContainer = new Mock<IPictureContainer>();

            var picture = new Picture();
            var pictureDAL = new Mock<IPictureDAL>();
            var pictureIdentity = new Mock<IPictureIdentity>();
            pictureDAL.Setup(x => x.GetAsync(pictureIdentity.Object)).ReturnsAsync(picture);

            var pictureGetService = new PictureService(pictureDAL.Object);
            
            // Act
            var action = new Func<Task>(() => pictureGetService.ValidateAsync(pictureContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_PictureNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var pictureContainer = new Mock<IPictureContainer>();
            pictureContainer.Setup(x => x.PictureId).Returns(id);
            var pictureIdentity = new Mock<IPictureIdentity>();
            var picture = new Picture();
            var pictureDAL = new Mock<IPictureDAL>();
            pictureDAL.Setup(x => x.GetAsync(pictureIdentity.Object)).ReturnsAsync((Picture) null);

            var pictureGetService = new PictureService(pictureDAL.Object);

            // Act
            var action = new Func<Task>(() => pictureGetService.ValidateAsync(pictureContainer.Object));
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Picture not found by id {id}");
        }
        
        [Test]
        public async Task CreateAsync_PictureValidationSucceed_CreatesStreet()
        {
            // Arrange
            var picture = new PictureUpdateModel();
            var expected = new Picture();
            
            var pictureDAL = new Mock<IPictureDAL>();
            pictureDAL.Setup(x => x.InsertAsync(disease)).ReturnsAsync(expected);

            var pictureService = new pictureService(pictureDAL.Object);
            
            // Act
            var result = await pictureService.CreateAsync(picture);
            
            // Assert
            result.Should().Be(expected);
        }
    }
}