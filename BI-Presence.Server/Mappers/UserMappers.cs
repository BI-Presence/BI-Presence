using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Dtos.User;
using BI_Presence.Server.Models;

namespace BI_Presence.Server.Mappers
{
    public static class UserMappers
    {
        public static GetUserDto ToGetUserDto(this User user)
        {
            return new GetUserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                BirthDate = user.BirthDate,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                SatuanKerja = user.SatuanKerja,
                Jabatan = user.Jabatan,
                NIK = user.NIK,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto dto)
        {
            return new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                BirthDate = dto.BirthDate,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                SatuanKerja = dto.SatuanKerja,
                Jabatan = dto.Jabatan,
                NIK = dto.NIK
            };
        }
    }
}