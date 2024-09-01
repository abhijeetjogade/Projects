using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;
using MedLab.Data;

namespace MedLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleTrackingsController : ControllerBase
    {
        private readonly MedLabDatabaseContext _context;

        public SampleTrackingsController(MedLabDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SampleTrackings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleTracking>>> GetSampleTracking()
        {
            return await _context.SampleTracking.ToListAsync();
        }

        // GET: api/SampleTrackings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleTracking>> GetSampleTracking(int id)
        {
            var sampleTracking = await _context.SampleTracking.FindAsync(id);

            if (sampleTracking == null)
            {
                return NotFound();
            }

            return sampleTracking;
        }

        // PUT: api/SampleTrackings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleTracking(int id, SampleTracking sampleTracking)
        {
            if (id != sampleTracking.SampleTrackingID)
            {
                return BadRequest();
            }

            _context.Entry(sampleTracking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleTrackingExists(id))
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

        // POST: api/SampleTrackings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SampleTracking>> PostSampleTracking(SampleTracking sampleTracking)
        {
            _context.SampleTracking.Add(sampleTracking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleTracking", new { id = sampleTracking.SampleTrackingID }, sampleTracking);
        }

        // DELETE: api/SampleTrackings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleTracking(int id)
        {
            var sampleTracking = await _context.SampleTracking.FindAsync(id);
            if (sampleTracking == null)
            {
                return NotFound();
            }

            _context.SampleTracking.Remove(sampleTracking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SampleTrackingExists(int id)
        {
            return _context.SampleTracking.Any(e => e.SampleTrackingID == id);
        }
    }
}
