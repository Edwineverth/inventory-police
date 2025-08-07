using InventoryPolice.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryPolice.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Device> Devices => Set<Device>();
        public DbSet<Officer> Officers => Set<Officer>();
        public DbSet<District> Districts => Set<District>();
    }
}
