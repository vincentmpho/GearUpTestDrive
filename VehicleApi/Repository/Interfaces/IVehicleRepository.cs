using VehicleApi.Models;

namespace VehicleApi.Repository.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicleById(int id);
        Task AddVehicle(Vehicle vehicle);
        Task UpdateVehicle(int id, Vehicle vehicle);
        Task DeleteVehicle(int id);
    }
}
