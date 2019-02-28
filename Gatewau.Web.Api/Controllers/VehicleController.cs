using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using provider = Gateway.Web.Api.Provider;

namespace Gateway.Web.Api.Controllers 
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly provider.IVehicleProvider _vehicleProvider;
        public VehicleController(provider.IVehicleProvider vehicleProvider)
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
        public IActionResult GetByStatusId(Int32 id)
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
        public IActionResult GetByCustomerId(Int64 id)
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

        [HttpGet("vehicles/customer/{customerId}/status/{statusId}")]
        public IActionResult GetByFiltrsId(Int64 customerId, Int32 statusId)
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
