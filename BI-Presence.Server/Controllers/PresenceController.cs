using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BI_Presence.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace BI_Presence.Server.Controllers
{
    [Route("api/presences")]
    [ApiController]
    public class PresenceController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        
        public PresenceController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPresences()
        {
            var presences = _context.Presences.ToList();

            return Ok(presences);
        }

        [HttpGet("{id}")]
        public IActionResult GetPresenceById([FromRoute] int id)
        {
            var presence = _context.Presences.FirstOrDefault(p => p.Id == id);

            if (presence == null)
            {
                return NotFound();
            }

            return Ok(presence);
        }
    }
}