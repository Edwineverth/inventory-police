using InventoryPolice.Domain.Entities;
using InventoryPolice.Domain.Repositories;
using InventoryPolice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryPolice.Infrastructure.Repositories;

public class DistrictRepository : IDistrictRepository
{
    private readonly ApplicationDbContext _context;

    public DistrictRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<District>> GetAllAsync()
    {
        return await _context.Districts
            .Include(d => d.Devices)
            .ToListAsync();
    }

    public Task<District?> GetByIdAsync(int id)
    {
        return _context.Districts
            .Include(d => d.Devices)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task AddAsync(District district)
    {
        _context.Districts.Add(district);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(District district)
    {
        _context.Entry(district).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var district = await _context.Districts.FindAsync(id);
        if (district != null)
        {
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
        }
    }
}
