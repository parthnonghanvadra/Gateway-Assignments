using Microsoft.AspNet.Identity;
using SBS.BusinessEntities;
using SBS.BusinessLogicLayer.Class;
using SBS.BusinessLogicLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBS.API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        [Authorize]
        [Route("Account/Login")]
        public IHttpActionResult Login()
        {
            return Ok();
        }

        // POST: api/Register
        [HttpPost]
        [Route("Account/Register")]
        public IHttpActionResult Register([FromBody] Customer customer)
        {
            
            string response = _customerManager.Register(customer);
            if (response.Equals("created"))
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
