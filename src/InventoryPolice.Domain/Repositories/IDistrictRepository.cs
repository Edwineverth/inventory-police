using InventoryPolice.Domain.Entities;

namespace InventoryPolice.Domain.Repositories;

public interface IDistrictRepository
{
    Task<IEnumerable<District>> GetAllAsync();
    Task<District?> GetByIdAsync(int id);
    Task AddAsync(District district);
    Task UpdateAsync(District district);
    Task DeleteAsync(int id);
}
