using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegBEnd.Models;

namespace RegBEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentdetailController : ControllerBase
    {
        private readonly PaymentDetailContex _context;

        public PaymentdetailController(PaymentDetailContex context)
        {
            _context = context;
        }

        // GET: api/Paymentdetail
        [HttpGet]
        public IEnumerable<Paymentdetail> GetPaymentdetails()
        {
            return _context.Paymentdetails;
        }

        // GET: api/Paymentdetail/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentdetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentdetail = await _context.Paymentdetails.FindAsync(id);

            if (paymentdetail == null)
            {
                return NotFound();
            }

            return Ok(paymentdetail);
        }

        // PUT: api/Paymentdetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentdetail([FromRoute] int id, [FromBody] Paymentdetail paymentdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentdetail.NIC)
            {
                return BadRequest();
            }

            _context.Entry(paymentdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentdetailExists(id))
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

        // POST: api/Paymentdetail
        [HttpPost]
        public async Task<IActionResult> PostPaymentdetail([FromBody] Paymentdetail paymentdetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Paymentdetails.Add(paymentdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentdetail", new { id = paymentdetail.NIC }, paymentdetail);
        }

        // DELETE: api/Paymentdetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentdetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentdetail = await _context.Paymentdetails.FindAsync(id);
            if (paymentdetail == null)
            {
                return NotFound();
            }

            _context.Paymentdetails.Remove(paymentdetail);
            await _context.SaveChangesAsync();

            return Ok(paymentdetail);
        }

        private bool PaymentdetailExists(int id)
        {
            return _context.Paymentdetails.Any(e => e.NIC == id);
        }
    }
}