using InventoryPolice.Domain.Entities;

namespace InventoryPolice.Application.Interfaces;

public interface IOfficerService
{
    Task<IEnumerable<Officer>> GetOfficersAsync();
    Task<Officer?> GetOfficerAsync(int id);
    Task<Officer> CreateOfficerAsync(Officer officer);
    Task UpdateOfficerAsync(Officer officer);
    Task DeleteOfficerAsync(int id);
}
