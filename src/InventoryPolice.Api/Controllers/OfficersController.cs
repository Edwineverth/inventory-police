using InventoryPolice.Application.Interfaces;
using InventoryPolice.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPolice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OfficersController : ControllerBase
{
    private readonly IOfficerService _service;

    public OfficersController(IOfficerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Officer>>> GetOfficers()
    {
        var officers = await _service.GetOfficersAsync();
        return Ok(officers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Officer>> GetOfficer(int id)
    {
        var officer = await _service.GetOfficerAsync(id);
        if (officer == null) return NotFound();
        return officer;
    }

    [HttpPost]
    public async Task<ActionResult<Officer>> PostOfficer(Officer officer)
    {
        await _service.CreateOfficerAsync(officer);
        return CreatedAtAction(nameof(GetOfficer), new { id = officer.Id }, officer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOfficer(int id, Officer officer)
    {
        if (id != officer.Id) return BadRequest();
        await _service.UpdateOfficerAsync(officer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOfficer(int id)
    {
        await _service.DeleteOfficerAsync(id);
        return NoContent();
    }
}
