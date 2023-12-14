using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleDeEstoque.Controllers;
using ControleDeEstoque.Model;
using ControleDeEstoque.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace ControleDeEstoqueTests.ControllersTestes
{
    public class UserControllerTests
    {
        // [Fact]
        // public async Task Post_ReturnsOkResultWhenUserIsCreated()
        // {
        //     // Arrange
        //     var mockUserRepository = new Mock<IUserRepository>();
        //     var controller = new UserController(mockUserRepository.Object);
        //     var user = new User { Id = 1, Nome = "Usuário Teste" };

        //     // Act
        //     var result = await controller.Post(user);

        //     // Assert
        //     var okResult = Assert.IsType<OkObjectResult>(result);
        //     Assert.Equal("Usuário adicionado com sucesso", okResult.Value);
        // }

        // [Fact]
        // public async Task Delete_ReturnsOkResultWhenUserIsDeleted()
        // {
        //     // Arrange
        //     var mockUserRepository = new Mock<IUserRepository>();
        //     var user = new User { Id = 1, Nome = "Usuário Teste" };
        //     mockUserRepository.Setup(repo => repo.GetUser(1)).ReturnsAsync(user);

        //     var controller = new UserController(mockUserRepository.Object);

        //     // Act
        //     var result = await controller.Delete(1);

        //     // Assert
        //     var okResult = Assert.IsType<OkObjectResult>(result);
        //     Assert.Equal("Usuário removido com sucesso", okResult.Value);
        // }
    }
}