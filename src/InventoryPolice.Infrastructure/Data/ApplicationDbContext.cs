using InventoryPolice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryPolice.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Device> Devices => Set<Device>();
    public DbSet<Officer> Officers => Set<Officer>();
    public DbSet<District> Districts => Set<District>();
}
