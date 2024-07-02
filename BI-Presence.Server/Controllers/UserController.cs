using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Data;
using BI_Presence.Server.Dtos.User;
using BI_Presence.Server.Interfaces;
using BI_Presence.Server.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BI_Presence.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(ApplicationDBContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() // janlup tambahin search name by query, sort by query and pagination by query
        {
            var users = await _userRepository.GetAllUsers();

            var usersDto = users.Select(u => u.ToGetUserDto());

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToGetUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto dto)
        {
            var user = dto.ToUserFromCreateDTO();

            await _userRepository.CreateUser(user);

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user.ToGetUserDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequestDto dto)
        {
            var user = await _userRepository.UpdateUser(id, dto);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToGetUserDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userRepository.DeleteUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}