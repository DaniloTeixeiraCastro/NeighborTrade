using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using FluentAssertions;
using NeighborTrade.Models;
using NeighborTrade.Services;
using NeighborTrade.Repositories;

public class UserServiceTests
{
    [Fact] // Indica que este é um teste unitário
    public void GetUserById_ShouldReturnUser_WhenUserExists()
    {
        // Arrange (Preparação)
        var mockRepo = new Mock<IUserRepository>(); // Criar um mock do repositório
        mockRepo.Setup(repo => repo.GetById(1)).Returns(new User { Id = 1, Name = "Teste" });

        var userService = new UserService(mockRepo.Object); // Injetar o mock no serviço

        // Act (Ação)
        var result = userService.GetUserById(1);

        // Assert (Verificação)
        result.Should().NotBeNull();
        result.Name.Should().Be("Teste");
    }
}