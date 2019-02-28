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
    public class CustomerController : ControllerBase
    {
        private readonly provider.ICustomerProvider _customerProvider;
        public CustomerController(provider.ICustomerProvider customerProvider)
        {
            _customerProvider = customerProvider;
        }


        [HttpGet("customers")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _customerProvider.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}