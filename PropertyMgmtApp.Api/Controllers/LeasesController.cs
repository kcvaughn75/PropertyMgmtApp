using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertyMgmtApp.Api.Data;
using PropertyMgmtApp.Api.Models;

namespace PropertyMgmtApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeasesController : ControllerBase
    {
        private readonly PropertyMgmtDbContext _context;

        public LeasesController(PropertyMgmtDbContext context)
        {
            _context = context;
        }

        // GET: api/Leases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lease>>> GetLeases()
        {
            return await _context.Leases.ToListAsync();
        }

        // GET: api/Leases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lease>> GetLease(int id)
        {
            var lease = await _context.Leases.FindAsync(id);

            if (lease == null)
            {
                return NotFound();
            }

            return lease;
        }

        // PUT: api/Leases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLease(int id, Lease lease)
        {
            if (id != lease.Id)
            {
                return BadRequest();
            }

            _context.Entry(lease).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaseExists(id))
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

        // POST: api/Leases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lease>> PostLease(Lease lease)
        {
            _context.Leases.Add(lease);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLease", new { id = lease.Id }, lease);
        }

        // DELETE: api/Leases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLease(int id)
        {
            var lease = await _context.Leases.FindAsync(id);
            if (lease == null)
            {
                return NotFound();
            }

            _context.Leases.Remove(lease);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LeaseExists(int id)
        {
            return _context.Leases.Any(e => e.Id == id);
        }
    }
}
