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
    public class PaymentTransactionsController : ControllerBase
    {
        private readonly MedDbContext _context;

        public PaymentTransactionsController(MedDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTransaction>>> GetPaymentTransaction()
        {
            return await _context.PaymentTransaction.ToListAsync();
        }

        // GET: api/PaymentTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTransaction>> GetPaymentTransaction(int id)
        {
            var paymentTransaction = await _context.PaymentTransaction.FindAsync(id);

            if (paymentTransaction == null)
            {
                return NotFound();
            }

            return paymentTransaction;
        }

        // PUT: api/PaymentTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTransaction(int id, PaymentTransaction paymentTransaction)
        {
            if (id != paymentTransaction.TransactionID)
            {
                return BadRequest();
            }

            _context.Entry(paymentTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTransactionExists(id))
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

        // POST: api/PaymentTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTransaction>> PostPaymentTransaction(PaymentTransaction paymentTransaction)
        {
            _context.PaymentTransaction.Add(paymentTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTransaction", new { id = paymentTransaction.TransactionID }, paymentTransaction);
        }

        // DELETE: api/PaymentTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTransaction(int id)
        {
            var paymentTransaction = await _context.PaymentTransaction.FindAsync(id);
            if (paymentTransaction == null)
            {
                return NotFound();
            }

            _context.PaymentTransaction.Remove(paymentTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTransactionExists(int id)
        {
            return _context.PaymentTransaction.Any(e => e.TransactionID == id);
        }
    }
}
