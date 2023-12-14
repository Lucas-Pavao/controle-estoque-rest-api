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
        public async Task Post_ReturnsBadRequestWhenBodyIsInvalid()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);
            controller.ModelState.AddModelError("error", "some error message"); // Simulate an invalid model state

            // Act
            var result = await controller.Post(new Produto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result); // Corrected: Expecting BadRequestObjectResult
        }

        [Fact]
        public async Task Post_ReturnsOkResultWhenProductIsCreated()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);
            var produto = new Produto { Id = 1, Nome = "Produto Teste", Preco = 10.0, Quantidade = 5, IdUser = 1 };

            // Act
            var result = await controller.Post(produto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // Corrected: Expecting OkObjectResult
            Assert.Equal("Produto adicionado com sucesso", okResult.Value);
        }

        [Fact]
        public async Task Put_ReturnsBadRequestWhenBodyIsInvalid()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);
            controller.ModelState.AddModelError("error", "some error message"); // Simulate an invalid model state

            // Act
            var result = await controller.Put(1, new Produto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result); // Corrected: Expecting BadRequestObjectResult
        }

        [Fact]
        public async Task Put_ReturnsOkResultWhenProductIsUpdated()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);
            var existingProduto = new Produto { Id = 1, Nome = "Produto Antigo", Preco = 10.0, Quantidade = 5, IdUser = 1 };
            var updatedProduto = new Produto { Id = 1, Nome = "Produto Atualizado", Preco = 20.0, Quantidade = 10, IdUser = 1 };
            mockProdutoRepository.Setup(repo => repo.GetProduto(1)).ReturnsAsync(existingProduto);

            // Act
            var result = await controller.Put(1, updatedProduto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // Corrected: Expecting OkObjectResult
            Assert.Equal("Produto atualizado com sucesso", okResult.Value);
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundWhenProductNotFound()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            mockProdutoRepository.Setup(repo => repo.GetProduto(1)).ReturnsAsync((Produto)null);

            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOkResultWhenProductIsDeleted()
        {
            // Arrange
            var mockProdutoRepository = new Mock<IProdutoRepository>();
            var mockUserRepository = new Mock<IUserRepository>();
            var produto = new Produto { Id = 1, Nome = "Produto Teste", Preco = 10.0, Quantidade = 5, IdUser = 1 };
            mockProdutoRepository.Setup(repo => repo.GetProduto(1)).ReturnsAsync(produto);

            var controller = new ProdutoController(mockProdutoRepository.Object, mockUserRepository.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // Corrected: Expecting OkObjectResult
            Assert.Equal("Produto excluído com sucesso", okResult.Value);
        }

    }
}
