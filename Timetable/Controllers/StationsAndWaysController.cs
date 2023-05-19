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
    public class StationsAndWaysController : ControllerBase
    {
        private readonly TimetableContext _context;

        public StationsAndWaysController(TimetableContext context)
        {
            _context = context;
        }

        // GET: api/StationsAndWays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationAndWay>>> GetStationsAndWays()
        {
          if (_context.StationsAndWays == null)
          {
              return NotFound();
          }
            return await _context.StationsAndWays.ToListAsync();
        }

        // GET: api/StationsAndWays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StationAndWay>> GetStationAndWay(int id)
        {
          if (_context.StationsAndWays == null)
          {
              return NotFound();
          }
            var stationAndWay = await _context.StationsAndWays.FindAsync(id);

            if (stationAndWay == null)
            {
                return NotFound();
            }

            return stationAndWay;
        }

        // PUT: api/StationsAndWays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStationAndWay(int id, StationAndWay stationAndWay)
        {
            if (id != stationAndWay.stationAndWayId)
            {
                return BadRequest();
            }

            _context.Entry(stationAndWay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StationAndWayExists(id))
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

        // POST: api/StationsAndWays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StationAndWay>> PostStationAndWay(StationAndWay stationAndWay)
        {
          if (_context.StationsAndWays == null)
          {
              return Problem("Entity set 'TimetableContext.StationsAndWays'  is null.");
          }
            _context.StationsAndWays.Add(stationAndWay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStationAndWay", new { id = stationAndWay.stationAndWayId }, stationAndWay);
        }

        // DELETE: api/StationsAndWays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStationAndWay(int id)
        {
            if (_context.StationsAndWays == null)
            {
                return NotFound();
            }
            var stationAndWay = await _context.StationsAndWays.FindAsync(id);
            if (stationAndWay == null)
            {
                return NotFound();
            }

            _context.StationsAndWays.Remove(stationAndWay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StationAndWayExists(int id)
        {
            return (_context.StationsAndWays?.Any(e => e.stationAndWayId == id)).GetValueOrDefault();
        }
    }
}
