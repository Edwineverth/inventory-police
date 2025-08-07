using InventoryPolice.Domain.Entities;
using InventoryPolice.Domain.Repositories;
using InventoryPolice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryPolice.Infrastructure.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly ApplicationDbContext _context;

    public DeviceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _context.Devices
            .Include(d => d.Officer)
            .Include(d => d.District)
            .ToListAsync();
    }

    public Task<Device?> GetByIdAsync(int id)
    {
        return _context.Devices
            .Include(d => d.Officer)
            .Include(d => d.District)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(Device device)
    {
        _context.Devices.Add(device);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Device device)
    {
        _context.Entry(device).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var device = await _context.Devices.FindAsync(id);
        if (device != null)
        {
            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();
        }
    }
}
