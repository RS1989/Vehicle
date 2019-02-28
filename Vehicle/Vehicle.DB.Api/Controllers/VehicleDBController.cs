using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle.DB.Api.Provider;

namespace Vehicle.DB.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDBController : ControllerBase
    {
        private readonly IVehicleProider _vehicleProvider;
        public VehicleDBController(IVehicleProider vehicleProvider)
        {
            _vehicleProvider = vehicleProvider;
        }

        [HttpGet("vehicles")]
        public IActionResult GetAllVehicles()
        {
            try
            {
                var result = _vehicleProvider.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("vehicles/status/{id}")]
        public IActionResult GetAllVehiclesByStatusId(Int32 id)
        {
            try
            {
                var result = _vehicleProvider.GetByStatusId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("vehicles/customer/{id}")]
        public IActionResult GetAllVehiclesByCustomerId(Int64 id)
        {
            try
            {
                var result = _vehicleProvider.GetByCustomerId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("update-status")]
        public IActionResult UpdateVehicleStatus(Models.Vehicle vehicle)
        {
            try
            {
                var result = _vehicleProvider.UpdateVehicleStatus(vehicle);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("vehicles/customer/{customerId}/status/{statusId}")]
        public IActionResult GetAllVehiclesByCustomerIdAndStatusId(Int64 customerId, Int32 statusId)
        {
            try
            {
                var result = _vehicleProvider.GetVehicleByStatusAndCustomerId(statusId, customerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}