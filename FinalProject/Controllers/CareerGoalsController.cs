using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;
using CareerGoals = FinalProject.Models.CareerGoals;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerGoalsController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public CareerGoalsController(FinalProjectContext context)
        {
            _context = context;
        }

      
        [HttpGet("{id:int?}")]
        public async Task<ActionResult<IEnumerable<CareerGoals>>> GetCareerGoals(int? id)
        {
            if (id == null || id == 0)
            {
                return await _context.CareerGoals.Take(5).ToListAsync();
            }
            else
            {
                var careerGoals = await _context.CareerGoals.FindAsync(id);

                if (careerGoals == null)
                {
                    return NotFound();
                }

                return new List<CareerGoals> { careerGoals };
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerGoals(int id, CareerGoals careerGoals)
        {
            if (id != careerGoals.Id)
            {
                return BadRequest();
            }

            _context.Entry(careerGoals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerGoalsExists(id))
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
        public async Task<ActionResult<CareerGoals>> PostCareerGoals(CareerGoals careerGoals)
        {
            _context.CareerGoals.Add(careerGoals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareerGoals", new { id = careerGoals.Id }, careerGoals);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareerGoals(int id)
        {
            var careerGoals = await _context.CareerGoals.FindAsync(id);
            if (careerGoals == null)
            {
                return NotFound();
            }

            _context.CareerGoals.Remove(careerGoals);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CareerGoalsExists(int id)
        {
            return _context.CareerGoals.Any(e => e.Id == id);
        }
    }
}
