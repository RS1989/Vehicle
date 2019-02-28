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
    public class CustomerDbController : ControllerBase
    {
        private readonly ICustomerProvider _customerProviider;
        public CustomerDbController(ICustomerProvider customerProviider)
        {
            _customerProviider = customerProviider;
        }

        [HttpGet("customers")]
        public IActionResult GetAllCustomer()
        {
            try
            {
                var result = _customerProviider.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}