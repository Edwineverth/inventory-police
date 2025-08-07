using InventoryPolice.Application.Interfaces;
using InventoryPolice.Domain.Entities;
using InventoryPolice.Domain.Repositories;

namespace InventoryPolice.Application.Services;

public class OfficerService : IOfficerService
{
    private readonly IOfficerRepository _repository;

    public OfficerService(IOfficerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Officer>> GetOfficersAsync() => _repository.GetAllAsync();

    public Task<Officer?> GetOfficerAsync(int id) => _repository.GetByIdAsync(id);

    public async Task<Officer> CreateOfficerAsync(Officer officer)
    {
        await _repository.AddAsync(officer);
        return officer;
    }

    public Task UpdateOfficerAsync(Officer officer) => _repository.UpdateAsync(officer);

    public Task DeleteOfficerAsync(int id) => _repository.DeleteAsync(id);
}
