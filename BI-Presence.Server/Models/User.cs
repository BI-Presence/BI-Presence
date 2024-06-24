using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BI_Presence.Server.Models
{
    public class User
    {
        public enum RoleEnum
        {
            Supervisor,
            Employee
        }

        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleEnum Role { get; set; } = RoleEnum.Employee;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string SatuanKerja { get; set; } = string.Empty;
        public string Jabatan { get; set; } = string.Empty;
        public string NIK { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<Presence> Presences { get; } = new List<Presence>();
    }
}