using InventoryPolice.Domain.Entities;

namespace InventoryPolice.Application.Interfaces;

public interface IDistrictService
{
    Task<IEnumerable<District>> GetDistrictsAsync();
    Task<District?> GetDistrictAsync(int id);
    Task<District> CreateDistrictAsync(District district);
    Task UpdateDistrictAsync(District district);
    Task DeleteDistrictAsync(int id);
}
