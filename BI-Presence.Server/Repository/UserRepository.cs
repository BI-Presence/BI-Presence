using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Data;
using BI_Presence.Server.Dtos.User;
using BI_Presence.Server.Interfaces;
using BI_Presence.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BI_Presence.Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAllUsers()
        {
            return _context.Users.ToListAsync();
        }

        public Task<User?> GetUserById(int id)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> UpdateUser(int id, UpdateUserRequestDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
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

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}