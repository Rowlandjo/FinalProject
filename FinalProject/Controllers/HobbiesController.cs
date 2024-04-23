using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using Hobby = FinalProject.Models.Hobby;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public HobbiesController(FinalProjectContext context)
        {
            _context = context;
        }

             [HttpGet("{id:int?}")]
        public async Task<ActionResult<IEnumerable<Hobby>>> GetHobby(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.Hobby.Take(5).ToListAsync();
            }
            else
            {
                var hobby = await _context.Hobby.FindAsync(id);

                if (hobby == null)
                {
                    return NotFound();
                }

                return new List<Hobby> { hobby };
            }
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHobby(int id, Hobby hobby)
        {
            if (id != hobby.Id)
            {
                return BadRequest();
            }

            _context.Entry(hobby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HobbyExists(id))
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

              [HttpPost("{id}")]
        public async Task<ActionResult<Hobby>> PostHobby(Hobby hobby)
        {
            _context.Hobby.Add(hobby);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHobby", new { id = hobby.Id }, hobby);
        }

               [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHobby(int id)
        {
            var hobby = await _context.Hobby.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }

            _context.Hobby.Remove(hobby);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HobbyExists(int id)
        {
            return _context.Hobby.Any(e => e.Id == id);
        }
    }
}
