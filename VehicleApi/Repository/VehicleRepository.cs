using Microsoft.EntityFrameworkCore;
using VehicleApi.Data;
using VehicleApi.Models;
using VehicleApi.Repository.Interfaces;

namespace VehicleApi.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
            private readonly ApiDbContext _context;

            public VehicleRepository(ApiDbContext context)
            {
                _context = context;
            }
            public async Task AddVehicle(Vehicle vehicle)
            {
                await _context.Vehicles.AddAsync(vehicle);
                await _context.SaveChangesAsync();

            }

            public async Task DeleteVehicle(int id)
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }

            public async Task<List<Vehicle>> GetAllVehicles()
            {

                var vehicle = await _context.Vehicles.ToListAsync();
                return vehicle;
            }

            public async Task<Vehicle> GetVehicleById(int id)
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
                return vehicle;
            }

            public async Task UpdateVehicle(int id, Vehicle vehicle)
            {
                var vehicleObj = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
                vehicleObj.Name = vehicle.Name;
                vehicleObj.ImageUrl = vehicle.ImageUrl;
                vehicleObj.Height = vehicle.Height;
                vehicleObj.Width = vehicle.Width;
                vehicleObj.MaxSpeed = vehicle.MaxSpeed;
                vehicleObj.Price = vehicle.Price;
                vehicleObj.Displacement = vehicle.Displacement;

                await _context.SaveChangesAsync();

            }
        }
}
