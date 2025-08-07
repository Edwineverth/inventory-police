using InventoryPolice.Application.Interfaces;
using InventoryPolice.Domain.Entities;
using InventoryPolice.Domain.Repositories;

namespace InventoryPolice.Application.Services;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _repository;

    public DeviceService(IDeviceRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Device>> GetDevicesAsync() => _repository.GetAllAsync();

    public Task<Device?> GetDeviceAsync(int id) => _repository.GetByIdAsync(id);

    public async Task<Device> CreateDeviceAsync(Device device)
    {
        await _repository.AddAsync(device);
        return device;
    }

    public Task UpdateDeviceAsync(Device device) => _repository.UpdateAsync(device);

    public Task DeleteDeviceAsync(int id) => _repository.DeleteAsync(id);
}
