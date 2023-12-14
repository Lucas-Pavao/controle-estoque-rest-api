
using ControleDeEstoque.Model;
using ControleDeEstoque.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;


        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                // Tenta obter a lista de Users
                var users = await userRepository.GetUsers();
                // Verifica se há Users na lista e retorna a resposta apropriada
                return users.Any() ? Ok(users) : NoContent();
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                // Tenta obter um User pelo ID
                var user = await userRepository.GetUser(id);
                // Verifica se o User foi encontrado e retorna a resposta apropriada
                return user != null ? Ok(user) : NotFound($"User com ID {id} não encontrado");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            try
            {
                // Adiciona um novo User
                userRepository.AddUser(user);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await userRepository.SaveChangesAsync() ? Ok("User adicionado com sucesso") : BadRequest("Falha ao adicionar o User");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            try
            {
                // Verifica se o ID informado é o mesmo do User
                if (id != user.Id)
                    return BadRequest($"Não foi possível atualizar o User com ID {id}");

                // Atualiza o User
                userRepository.UpdateUser(user);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await userRepository.SaveChangesAsync() ? Ok("User atualizado com sucesso") : BadRequest("Falha ao atualizar o User");
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
                // Tenta obter o User pelo ID
                var user = await userRepository.GetUser(id);
                // Verifica se o User foi encontrado
                if (user == null)
                    return NotFound($"User com ID {id} não encontrado");

                // Remove o User do repositório
                userRepository.DeleteUser(user);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await userRepository.SaveChangesAsync() ? Ok("User removido com sucesso") : BadRequest("Falha ao remover o User");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }

        }
    }
}