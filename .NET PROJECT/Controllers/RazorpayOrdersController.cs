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
    public class RazorpayOrdersController : ControllerBase
    {
        private readonly MedDbContext _context;

        public RazorpayOrdersController(MedDbContext context)
        {
            _context = context;
        }

        // GET: api/RazorpayOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RazorpayOrder>>> GetRazorpayOrder()
        {
            return await _context.RazorpayOrder.ToListAsync();
        }

        // GET: api/RazorpayOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RazorpayOrder>> GetRazorpayOrder(int id)
        {
            var razorpayOrder = await _context.RazorpayOrder.FindAsync(id);

            if (razorpayOrder == null)
            {
                return NotFound();
            }

            return razorpayOrder;
        }

        // PUT: api/RazorpayOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRazorpayOrder(int id, RazorpayOrder razorpayOrder)
        {
            if (id != razorpayOrder.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(razorpayOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RazorpayOrderExists(id))
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

        // POST: api/RazorpayOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RazorpayOrder>> PostRazorpayOrder(RazorpayOrder razorpayOrder)
        {
            _context.RazorpayOrder.Add(razorpayOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRazorpayOrder", new { id = razorpayOrder.OrderID }, razorpayOrder);
        }

        // DELETE: api/RazorpayOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRazorpayOrder(int id)
        {
            var razorpayOrder = await _context.RazorpayOrder.FindAsync(id);
            if (razorpayOrder == null)
            {
                return NotFound();
            }

            _context.RazorpayOrder.Remove(razorpayOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RazorpayOrderExists(int id)
        {
            return _context.RazorpayOrder.Any(e => e.OrderID == id);
        }
    }
}
