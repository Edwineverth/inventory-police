using InventoryPolice.Api.Data;
using InventoryPolice.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryPolice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OfficersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Officer>>> GetOfficers()
        {
            return await _context.Officers
                .Include(o => o.Devices)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Officer>> GetOfficer(int id)
        {
            var officer = await _context.Officers
                .Include(o => o.Devices)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (officer == null) return NotFound();
            return officer;
        }

        [HttpPost]
        public async Task<ActionResult<Officer>> PostOfficer(Officer officer)
        {
            _context.Officers.Add(officer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOfficer), new { id = officer.Id }, officer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficer(int id, Officer officer)
        {
            if (id != officer.Id) return BadRequest();
            _context.Entry(officer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficer(int id)
        {
            var officer = await _context.Officers.FindAsync(id);
            if (officer == null) return NotFound();
            _context.Officers.Remove(officer);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
