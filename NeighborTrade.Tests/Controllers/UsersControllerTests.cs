using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using NeighborTrade.Controllers;
using NeighborTrade.Services;
using NeighborTrade.Models;

public class UsersControllerTests
{
    [Fact]
    public void GetUserById_ShouldReturnOk_WhenUserExists()
    {
        // Arrange
        var mockService = new Mock<IUserService>();
        mockService.Setup(service => service.GetUserById(1)).Returns(new User { Id = 1, Name = "Teste" });

        var controller = new UsersController(mockService.Object);

        // Act
        var result = controller.GetUserById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var user = Assert.IsType<User>(okResult.Value);
        Assert.Equal("Teste", user.Name);
    }
}