using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BI_Presence.Server.Dtos.User
{
    public class UpdateUserRequestDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Models.User.RoleEnum Role { get; set; } = Models.User.RoleEnum.Employee;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SatuanKerja { get; set; } = string.Empty;
        public string Jabatan { get; set; } = string.Empty;
        public string NIK { get; set; } = string.Empty;
    }
}