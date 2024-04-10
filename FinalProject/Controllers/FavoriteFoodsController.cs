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
    public class FavoriteFoodsController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public FavoriteFoodsController(FinalProjectContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FavoriteFood>>> GetFavoriteFood()
         {
            return await _context.FavoriteFood.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteFood>> GetFavoriteFood(int id)
        {
            var favoriteFood = await _context.FavoriteFood.FindAsync(id);

            if (favoriteFood == null)
            {
                return NotFound();
            }

            return favoriteFood;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavoriteFood(int id, FavoriteFood favoriteFood)
        {
            if (id != favoriteFood.Id)
            {
                return BadRequest();
            }

            _context.Entry(favoriteFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriteFoodExists(id))
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
        public async Task<ActionResult<FavoriteFood>> PostFavoriteFood(FavoriteFood favoriteFood)
        {
            _context.FavoriteFood.Add(favoriteFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavoriteFood", new { id = favoriteFood.Id }, favoriteFood);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriteFood(int id)
        {
            var favoriteFood = await _context.FavoriteFood.FindAsync(id);
            if (favoriteFood == null)
            {
                return NotFound();
            }

            _context.FavoriteFood.Remove(favoriteFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavoriteFoodExists(int id)
        {
            return _context.FavoriteFood.Any(e => e.Id == id);
        }
    }
}
