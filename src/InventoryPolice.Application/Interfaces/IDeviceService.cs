using InventoryPolice.Domain.Entities;

namespace InventoryPolice.Application.Interfaces;

public interface IDeviceService
{
    Task<IEnumerable<Device>> GetDevicesAsync();
    Task<Device?> GetDeviceAsync(int id);
    Task<Device> CreateDeviceAsync(Device device);
    Task UpdateDeviceAsync(Device device);
    Task DeleteDeviceAsync(int id);
}
