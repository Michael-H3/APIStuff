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
    public class BattleController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BattleController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Battle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battle>>> GetBattle()
        {
            return await _context.Battle.ToListAsync();
        }

        // GET: api/Battle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Battle>> GetBattle(int id)
        {
            var battle = await _context.Battle.FindAsync(id);

            if (battle == null)
            {
                return NotFound();
            }

            return battle;
        }

        // PUT: api/Battle/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBattle(int id, Battle battle)
        {
            if (id != battle.battleID)
            {
                return BadRequest();
            }

            _context.Entry(battle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BattleExists(id))
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

        // POST: api/Battle
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Battle>> PostBattle(Battle battle)
        {
            _context.Battle.Add(battle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBattle", new { id = battle.battleID }, battle);
        }

        // DELETE: api/Battle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Battle>> DeleteBattle(int id)
        {
            var battle = await _context.Battle.FindAsync(id);
            if (battle == null)
            {
                return NotFound();
            }

            _context.Battle.Remove(battle);
            await _context.SaveChangesAsync();

            return battle;
        }

        private bool BattleExists(int id)
        {
            return _context.Battle.Any(e => e.battleID == id);
        }
    }
}
