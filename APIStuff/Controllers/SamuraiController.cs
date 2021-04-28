﻿using System;
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
    public class SamuraiController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SamuraiController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Samurai
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurai()
        {
            return await _context.Samurai.ToListAsync();
        }

        //api/Samurai/join1m
        [HttpGet("join1m")]
        public async Task<ActionResult<Samurai>> GetSamurai22()
        {
            // var temp = await _context.Samurai.Include(s => s.samuraiBattles).ToListAsync(); //trækker ud fra en liste i en tabel
            //var temp2 = await _context.Samurai.Include(Battle => Battle.).ToListAsync();
            //var temp = await _context.Samurai.Select(s => s).ToListAsync();
            var temp = await _context.Samurai.Include(s => s.SamuraisInBattle).ToListAsync();

            return Ok(temp);
        }

        //api/Samurai/join1m
        [HttpGet("joinmm")]
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurai23()
        {
            var temp = await _context.Samurai.Include(s => s.SamuraisInBattle)
                .ThenInclude(sb => sb.Battle)

                .Where(blodig => blodig.name == "Gaara")
                .Select(x => new
                {
                    x.name,
                    test = x.SamuraisInBattle.Select(allsam => allsam.Battle.name)

                })
                .ToListAsync();

            //orderby, where eller group er efter dette join
            //eksempelvis
            //.where(base => base.battleproperty == noget)

                //m-m: array.include(s=>s.list).thenInclude(?)
                //table-table-table: table1.include(table2).include(table3)
            //var temp2 = await _context.Samurai.Include(Battle => Battle.).ToListAsync();
            return Ok(temp);
        }

        [HttpGet("JoinAnonymous")]

        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurai233()
        {
            var temp = await _context.Samurai.Include(s => s.SamuraisInBattle as List<SamuraisInBattle>)
                .ThenInclude(sb => sb.Battle).ToListAsync();
            //orderby, where eller group er efter dette join
            //eksempelvis
            //.where(base => base.battleproperty == noget)

            //m-m: array.include(s=>s.list).thenInclude(?)
            //table-table-table: table1.include(table2).include(table3)
            //var temp2 = await _context.Samurai.Include(Battle => Battle.).ToListAsync();
            return Ok(temp);
        }

        // GET: api/Samurai/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Samurai>> GetSamurai(int id)
        {
            var samurai = await _context.Samurai.FindAsync(id);

            if (samurai == null)
            {
                return NotFound();
            }

            return samurai;
        }

        // PUT: api/Samurai/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamurai(int id, Samurai samurai)
        {
            if (id != samurai.samuraiID)
            {
                return BadRequest();
            }

            _context.Entry(samurai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamuraiExists(id))
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

        // POST: api/Samurai
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Samurai>> PostSamurai(Samurai samurai)
        {
            _context.Samurai.Add(samurai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSamurai", new { id = samurai.samuraiID }, samurai);
        }

        // DELETE: api/Samurai/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Samurai>> DeleteSamurai(int id)
        {
            var samurai = await _context.Samurai.FindAsync(id);
            if (samurai == null)
            {
                return NotFound();
            }

            _context.Samurai.Remove(samurai);
            await _context.SaveChangesAsync();

            return samurai;
        }

        private bool SamuraiExists(int id)
        {
            return _context.Samurai.Any(e => e.samuraiID == id);
        }
    }
}
