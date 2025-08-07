using InventoryPolice.Application.Interfaces;
using InventoryPolice.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPolice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DistrictsController : ControllerBase
{
    private readonly IDistrictService _service;

    public DistrictsController(IDistrictService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
    {
        var districts = await _service.GetDistrictsAsync();
        return Ok(districts);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<District>> GetDistrict(int id)
    {
        var district = await _service.GetDistrictAsync(id);
        if (district == null) return NotFound();
        return district;
    }

    [HttpPost]
    public async Task<ActionResult<District>> PostDistrict(District district)
    {
        await _service.CreateDistrictAsync(district);
        return CreatedAtAction(nameof(GetDistrict), new { id = district.Id }, district);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDistrict(int id, District district)
    {
        if (id != district.Id) return BadRequest();
        await _service.UpdateDistrictAsync(district);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDistrict(int id)
    {
        await _service.DeleteDistrictAsync(id);
        return NoContent();
    }
}
