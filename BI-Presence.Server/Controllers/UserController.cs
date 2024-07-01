using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Data;
using BI_Presence.Server.Dtos.User;
using BI_Presence.Server.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAllUsers() // janlup tambahin search name by query, sort by query and pagination by query
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto dto)
        {
            var user = dto.ToUserFromCreateDTO();

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user.ToGetUserDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequestDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Role = dto.Role;
            user.BirthDate = dto.BirthDate;
            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.SatuanKerja = dto.SatuanKerja;
            user.Jabatan = dto.Jabatan;
            user.NIK = dto.NIK;
            user.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(user.ToGetUserDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}