using InventoryPolice.Application.Interfaces;
using InventoryPolice.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InventoryPolice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DevicesController : ControllerBase
{
    private readonly IDeviceService _service;

    public DevicesController(IDeviceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
    {
        var devices = await _service.GetDevicesAsync();
        return Ok(devices);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Device>> GetDevice(int id)
    {
        var device = await _service.GetDeviceAsync(id);
        if (device == null) return NotFound();
        return device;
    }

    [HttpPost]
    public async Task<ActionResult<Device>> PostDevice(Device device)
    {
        await _service.CreateDeviceAsync(device);
        return CreatedAtAction(nameof(GetDevice), new { id = device.Id }, device);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDevice(int id, Device device)
    {
        if (id != device.Id) return BadRequest();
        await _service.UpdateDeviceAsync(device);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(int id)
    {
        await _service.DeleteDeviceAsync(id);
        return NoContent();
    }
}
