using InventoryPolice.Domain.Entities;
using InventoryPolice.Domain.Repositories;
using InventoryPolice.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryPolice.Infrastructure.Repositories;

public class OfficerRepository : IOfficerRepository
{
    private readonly ApplicationDbContext _context;

    public OfficerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Officer>> GetAllAsync()
    {
        return await _context.Officers
            .Include(o => o.Devices)
            .ToListAsync();
    }

    public Task<Officer?> GetByIdAsync(int id)
    {
        return _context.Officers
            .Include(o => o.Devices)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Officer officer)
    {
        _context.Officers.Add(officer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Officer officer)
    {
        _context.Entry(officer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var officer = await _context.Officers.FindAsync(id);
        if (officer != null)
        {
            _context.Officers.Remove(officer);
            await _context.SaveChangesAsync();
        }
    }
}
