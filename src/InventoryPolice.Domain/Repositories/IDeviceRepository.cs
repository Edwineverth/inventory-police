using InventoryPolice.Domain.Entities;

namespace InventoryPolice.Domain.Repositories;

public interface IDeviceRepository
{
    Task<IEnumerable<Device>> GetAllAsync();
    Task<Device?> GetByIdAsync(int id);
    Task AddAsync(Device device);
    Task UpdateAsync(Device device);
    Task DeleteAsync(int id);
}
