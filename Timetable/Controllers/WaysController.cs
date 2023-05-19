using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Timetable.Models;

namespace Timetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaysController : ControllerBase
    {
        private readonly TimetableContext _context;

        public WaysController(TimetableContext context)
        {
            _context = context;
        }

        // GET: api/Ways
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Way>>> GetRoutes()
        {
          if (_context.Ways == null)
          {
              return NotFound();
          }
            return await _context.Ways.ToListAsync();
        }

        // GET: api/Ways/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Way>> GetWay(int id)
        {
          if (_context.Ways == null)
          {
              return NotFound();
          }
            var way = await _context.Ways.FindAsync(id);

            if (way == null)
            {
                return NotFound();
            }

            return way;
        }

        // PUT: api/Ways/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWay(int id, Way way)
        {
            if (id != way.wayId)
            {
                return BadRequest();
            }

            _context.Entry(way).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WayExists(id))
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

        // POST: api/Ways
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Way>> PostWay(Way way)
        {
          if (_context.Ways == null)
          {
              return Problem("Entity set 'TimetableContext.Routes'  is null.");
          }
            _context.Ways.Add(way);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWay", new { id = way.wayId }, way);
        }

        // DELETE: api/Ways/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWay(int id)
        {
            if (_context.Ways == null)
            {
                return NotFound();
            }
            var way = await _context.Ways.FindAsync(id);
            if (way == null)
            {
                return NotFound();
            }

            _context.Ways.Remove(way);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WayExists(int id)
        {
            return (_context.Ways?.Any(e => e.wayId == id)).GetValueOrDefault();
        }
    }
}
