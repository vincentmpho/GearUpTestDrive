using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleApi.Models;
using VehicleApi.Repository.Interfaces;

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleRepository.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var vehicles = await _vehicleRepository.GetVehicleById(id);
            return Ok(vehicles);
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] Vehicle vehicle)
        {
            await _vehicleRepository.AddVehicle(vehicle);
            return Ok(vehicle);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Udpate(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleRepository.UpdateVehicle(id, vehicle);
            return Ok(vehicle);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)

        {
            await _vehicleRepository.DeleteVehicle(id);
            return Ok();
        }
    }
}
