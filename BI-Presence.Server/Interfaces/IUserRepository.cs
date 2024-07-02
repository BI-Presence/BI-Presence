using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Models;

namespace BI_Presence.Server.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
    }
}