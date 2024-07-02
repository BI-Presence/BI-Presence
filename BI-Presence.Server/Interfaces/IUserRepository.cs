using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Dtos.User;
using BI_Presence.Server.Models;

namespace BI_Presence.Server.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();

        Task<User?> GetUserById(int id);

        Task<User> CreateUser(User user);

        Task<User?> UpdateUser(int id, UpdateUserRequestDto dto);

        Task<User?> DeleteUser(int id);
    }
}