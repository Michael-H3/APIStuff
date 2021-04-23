using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIStuff.Models;

namespace APIStuff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionHeroesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ActionHeroesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ActionHeroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActionHeroes>>> GetActionHeroes()
        {
            return await _context.ActionHeroes.ToListAsync();
        }

        [HttpGet("best")]

        public async Task<ActionResult<IEnumerable<ActionHeroes>>> GetActionHeroesBest()
        {
            return await _context.ActionHeroes.Where((a) => a.epicMovies > 5).ToListAsync();
        }

        [HttpGet("oldschool")]

        public async Task<ActionResult<IEnumerable<ActionHeroes>>> GetActionHeroesOldSchool()
        {
            DateTime newdate = new DateTime(2015, 12, 31, 5, 10, 20, DateTimeKind.Utc); //år, måned, dag, time, min, sek, format

            return await _context.ActionHeroes.Where((a) => a.Date < newdate).ToListAsync();
        }

        // GET: api/ActionHeroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActionHeroes>> GetActionHeroes(int id)
        {
            var actionHeroes = await _context.ActionHeroes.FindAsync(id);

            if (actionHeroes == null)
            {
                return NotFound();
            }

            return actionHeroes;
        }

        // PUT: api/ActionHeroes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActionHeroes(int id, ActionHeroes actionHeroes)
        {
            if (id != actionHeroes.ActionHeroesID)
            {
                return BadRequest();
            }

            _context.Entry(actionHeroes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActionHeroesExists(id))
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

        // POST: api/ActionHeroes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ActionHeroes>> PostActionHeroes(ActionHeroes actionHeroes)
        {
            _context.ActionHeroes.Add(actionHeroes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActionHeroes", new { id = actionHeroes.ActionHeroesID }, actionHeroes);
        }

        // DELETE: api/ActionHeroes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActionHeroes>> DeleteActionHeroes(int id)
        {
            var actionHeroes = await _context.ActionHeroes.FindAsync(id);
            if (actionHeroes == null)
            {
                return NotFound();
            }

            _context.ActionHeroes.Remove(actionHeroes);
            await _context.SaveChangesAsync();

            return actionHeroes;
        }

        private bool ActionHeroesExists(int id)
        {
            return _context.ActionHeroes.Any(e => e.ActionHeroesID == id);
        }
    }
}
