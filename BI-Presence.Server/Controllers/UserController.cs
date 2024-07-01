using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Data;
using BI_Presence.Server.Dtos.User;
using BI_Presence.Server.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace BI_Presence.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequestDto dto)
        {
            var user = dto.ToUserFromCreateDTO();

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user.ToGetUserDto());
        }
    }
}