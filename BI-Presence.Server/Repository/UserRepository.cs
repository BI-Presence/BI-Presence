using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Data;
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
    }
}