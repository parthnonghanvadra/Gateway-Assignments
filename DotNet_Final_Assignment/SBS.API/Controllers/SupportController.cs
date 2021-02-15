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
    public class SupportController : ApiController
    {
        private readonly ISupportManager _supportManager;

        public SupportController(ISupportManager supportManager)
        {
            _supportManager = supportManager;
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetDealers()
        {
            var dealers = _supportManager.GetDealers();

            if(dealers == null)
            {
                return InternalServerError();
            }
            return Ok(dealers);
        }

        [Authorize]
        [HttpGet]
        public IHttpActionResult GetManufacturers()
        {
            var manufacturers = _supportManager.GetManufacturers();

            if (manufacturers == null)
            {
                return InternalServerError();
            }
            return Ok(manufacturers);
        }
    }
}
