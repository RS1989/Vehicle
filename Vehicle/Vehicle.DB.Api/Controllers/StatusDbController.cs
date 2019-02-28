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
    public class StatusDbController : ControllerBase
    {
        private readonly IStatusProvider _statusProvider;
        public StatusDbController(IStatusProvider statusProvider)
        {
            _statusProvider = statusProvider;
        }

        [HttpGet("statuses")]
        public IActionResult GetAllStatuses()
        {
            try
            {
                var result = _statusProvider.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}