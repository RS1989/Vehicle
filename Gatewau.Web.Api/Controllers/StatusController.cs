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
    public class StatusController : ControllerBase
    {
        private readonly provider.IStatusProvider _statusProvider;
        public StatusController(provider.IStatusProvider statusProvider)
        {
            _statusProvider = statusProvider;
        }


        [HttpGet("statuses")]
        public IActionResult GetAll()
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