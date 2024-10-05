using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.Models;
using SistemaDeReservas.Services;

namespace SistemaDeReservas.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // Método para criar um novo usuário
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }

            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // Método para buscar todos os usuários
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // Método para buscar um usuário por ID
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Método para atualizar um usuário
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }

            await _userService.UpdateUser(id, user); // Removido a atribuição
            return NoContent();
        }

        // Método para deletar um usuário
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
