using InventoryPolice.Api.Data;
using InventoryPolice.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryPolice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistrictsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
            return await _context.Districts
                .Include(d => d.Devices)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<District>> GetDistrict(int id)
        {
            var district = await _context.Districts
                .Include(d => d.Devices)
                .FirstOrDefaultAsync(d => d.Id == id);
            if (district == null) return NotFound();
            return district;
        }

        [HttpPost]
        public async Task<ActionResult<District>> PostDistrict(District district)
        {
            _context.Districts.Add(district);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDistrict), new { id = district.Id }, district);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistrict(int id, District district)
        {
            if (id != district.Id) return BadRequest();
            _context.Entry(district).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            if (district == null) return NotFound();
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
