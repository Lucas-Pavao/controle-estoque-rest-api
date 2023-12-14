using ControleDeEstoque.Model;
using ControleDeEstoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IUserRepository userRepository;

        public ProdutoController(IProdutoRepository produtoRepository, IUserRepository userRepository)
        {
            this.produtoRepository = produtoRepository;
            this.userRepository = userRepository;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Tenta obter a lista de produtos
                var produtos = await produtoRepository.GetProdutos();
                // Verifica se há produtos na lista e retorna a resposta apropriada
                return produtos.Any() ? Ok(produtos) : NoContent();
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                // Tenta obter um produto pelo ID
                var produto = await produtoRepository.GetProduto(id);
                // Verifica se o produto foi encontrado e retorna a resposta apropriada
                return produto != null ? Ok(produto) : NotFound($"Produto com ID {id} não encontrado");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            try
            {
                // Adiciona um novo produto
                var user = await userRepository.GetUser(produto.IdUser);
                if (user == null)
                {
                    return BadRequest($"User with ID {produto.IdUser} not found. Cannot add product.");
                }

                produtoRepository.AddProduto(produto);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await produtoRepository.SaveChangesAsync() ? Ok("Produto adicionado com sucesso") : BadRequest("Falha ao adicionar o produto");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Produto produto)
        {
            try
            {
                // Tenta obter o produto existente pelo ID
                var existingProduto = await produtoRepository.GetProduto(id);
                // Verifica se o produto foi encontrado
                if (existingProduto == null)
                {
                    return NotFound($"Produto com ID {id} não encontrado");
                }

                // Check if the associated user exists
                var user = await userRepository.GetUser(produto.IdUser);
                if (user == null)
                {
                    return NotFound($"User with ID {produto.IdUser} not found. Cannot update product.");
                }

                // Atualiza as propriedades do produto existente
                existingProduto.Nome = existingProduto.Nome ?? produto.Nome;
                existingProduto.Preco = produto.Preco;
                existingProduto.Quantidade = produto.Quantidade;
                existingProduto.IdUser = produto.IdUser; // Update the user ID

                // Atualiza o produto no repositório
                produtoRepository.UpdateProduto(existingProduto);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await produtoRepository.SaveChangesAsync() ? Ok("Produto atualizado com sucesso") : BadRequest("Falha ao atualizar o produto");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Tenta obter o produto pelo ID
                var produto = await produtoRepository.GetProduto(id);
                // Verifica se o produto foi encontrado
                if (produto == null)
                {
                    return NotFound($"Produto com ID {id} não encontrado");
                }

                // Exclui o produto do repositório
                produtoRepository.DeleteProduto(produto);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await produtoRepository.SaveChangesAsync() ? Ok("Produto excluído com sucesso") : BadRequest("Falha ao excluir o produto");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}