using Microsoft.EntityFrameworkCore;
using VehicleApi.Models;

namespace VehicleApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
