using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pension_Management;

namespace Pension_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionersController : ControllerBase
    {
        private readonly PensionerContext _context;

        public PensionersController(PensionerContext context)
        {
            _context = context;
        }

        // GET: api/Pensioners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pensioner>>> GetPensioners()
        {
            return await _context.Pensioners.ToListAsync();
        }

        // GET: api/Pensioners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pensioner>> GetPensioner(long id)
        {
            var pensioner = await _context.Pensioners.FindAsync(id);

            if (pensioner == null)
            {
                return NotFound();
            }

            return pensioner;
        }

        // PUT: api/Pensioners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPensioner(long id, Pensioner pensioner)
        {
            if (id != pensioner.AadharNo)
            {
                return BadRequest();
            }

            _context.Entry(pensioner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PensionerExists(id))
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

        // POST: api/Pensioners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pensioner>> PostPensioner(Pensioner pensioner)
        {
            _context.Pensioners.Add(pensioner);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PensionerExists(pensioner.AadharNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPensioner", new { id = pensioner.AadharNo }, pensioner);
        }

        // DELETE: api/Pensioners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePensioner(long id)
        {
            var pensioner = await _context.Pensioners.FindAsync(id);
            if (pensioner == null)
            {
                return NotFound();
            }

            _context.Pensioners.Remove(pensioner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PensionerExists(long id)
        {
            return _context.Pensioners.Any(e => e.AadharNo == id);
        }
    }
}
