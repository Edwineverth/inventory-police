using InventoryPolice.Application.Interfaces;
using InventoryPolice.Domain.Entities;
using InventoryPolice.Domain.Repositories;

namespace InventoryPolice.Application.Services;

public class DistrictService : IDistrictService
{
    private readonly IDistrictRepository _repository;

    public DistrictService(IDistrictRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<District>> GetDistrictsAsync() => _repository.GetAllAsync();

    public Task<District?> GetDistrictAsync(int id) => _repository.GetByIdAsync(id);

    public async Task<District> CreateDistrictAsync(District district)
    {
        await _repository.AddAsync(district);
        return district;
    }

    public Task UpdateDistrictAsync(District district) => _repository.UpdateAsync(district);

    public Task DeleteDistrictAsync(int id) => _repository.DeleteAsync(id);
}
