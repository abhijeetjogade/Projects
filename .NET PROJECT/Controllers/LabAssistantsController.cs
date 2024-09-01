using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedLab.Data;
using MedLab.Models;

namespace MedLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabAssistantsController : ControllerBase
    {
        private readonly MedDbContext _context;

        public LabAssistantsController(MedDbContext context)
        {
            _context = context;
        }

        // GET: api/LabAssistants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LabAssistant>>> GetLabAssistant()
        {
            return await _context.LabAssistant.ToListAsync();
        }

        // GET: api/LabAssistants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LabAssistant>> GetLabAssistant(int id)
        {
            var labAssistant = await _context.LabAssistant.FindAsync(id);

            if (labAssistant == null)
            {
                return NotFound();
            }

            return labAssistant;
        }

        // PUT: api/LabAssistants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLabAssistant(int id, LabAssistant labAssistant)
        {
            if (id != labAssistant.LabAssistantId)
            {
                return BadRequest();
            }

            _context.Entry(labAssistant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LabAssistantExists(id))
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

        // POST: api/LabAssistants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LabAssistant>> PostLabAssistant(LabAssistant labAssistant)
        {
            _context.LabAssistant.Add(labAssistant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLabAssistant", new { id = labAssistant.LabAssistantId }, labAssistant);
        }

        // DELETE: api/LabAssistants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabAssistant(int id)
        {
            var labAssistant = await _context.LabAssistant.FindAsync(id);
            if (labAssistant == null)
            {
                return NotFound();
            }

            _context.LabAssistant.Remove(labAssistant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LabAssistantExists(int id)
        {
            return _context.LabAssistant.Any(e => e.LabAssistantId == id);
        }
    }
}
