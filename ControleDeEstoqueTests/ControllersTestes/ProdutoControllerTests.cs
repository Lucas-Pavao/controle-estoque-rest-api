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

namespace ControleDeEstoqueTests
{
    public class ProdutoControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResultWithProducts()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var produtos = new List<Produto> { new Produto { Id = 1, Nome = "Produto Teste", Preco = 10.0, Quantidade = 5, IdUser = 1 } };
            mockProdutoRepository.Setup(repo => repo.GetProdutos()).ReturnsAsync(produtos);

            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Produto>>(okResult.Value);
            Assert.Single(model);
        }

        [Fact]
        public async Task Get_ReturnsNoContentWhenNoProducts()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            mockProdutoRepository.Setup(repo => repo.GetProdutos()).ReturnsAsync(new List<Produto>());

            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]

        public async Task GetById_ReturnsNotFoundWhenProductNotFound()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            mockProdutoRepository.Setup(repo => repo.GetProduto(1)).ReturnsAsync((Produto)null);

            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]

        public async Task GetById_ReturnsOkResultWithProduct()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var produto = new Produto { Id = 1, Nome = "Produto Teste", Preco = 10.0, Quantidade = 5, IdUser = 1 };
            mockProdutoRepository.Setup(repo => repo.GetProduto(1)).ReturnsAsync(produto);

            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Produto>(okResult.Value);
            Assert.Equal(produto, model);

        }

        [Fact]
        public async Task Post_ReturnsBadRequestResultWhenProductIsInvalid()
        {
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var user = new User { Id = 1, Nome = "Teste", Email = "teste@gmail.com", Senha = "123456" };
            mockUserRepository.Setup(repo => repo.GetUser(It.IsAny<int>())).ReturnsAsync(user);
            var produto = new Produto { Nome = "", Preco = 0, Quantidade = 0, IdUser = 0 };
            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.Post(produto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


    }
}
