using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMember_Controller : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public TeamMember_Controller(FinalProjectContext context)
        {
            _context = context;
        }

     
        [HttpGet("{id:int?}")]
        public async Task<ActionResult<IEnumerable<TeamMember_>>> GetTeamMember_(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.TeamMember_.Take(5).ToListAsync();
            }
            else
            {
                var teamMember_ = await _context.TeamMember_.FindAsync(id);

                if (teamMember_ == null)
                {
                    return NotFound();
                }

                return new List<TeamMember_> { teamMember_ };
            }
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMember_(int id, TeamMember_ teamMember_)
        {
            if (id != teamMember_.Id)
            {
                return BadRequest();
            }

            _context.Entry(teamMember_).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMember_Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

  
        [HttpPost]
        public async Task<ActionResult<TeamMember_>> PostTeamMember_(TeamMember_ teamMember_)
        {
            _context.TeamMember_.Add(teamMember_);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamMember_", new { id = teamMember_.Id }, teamMember_);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember_(int id)
        {
            var teamMember_ = await _context.TeamMember_.FindAsync(id);
            if (teamMember_ == null)
            {
                return NotFound();
            }

            _context.TeamMember_.Remove(teamMember_);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamMember_Exists(int id)
        {
            return _context.TeamMember_.Any(e => e.Id == id);
        }
    }
}
