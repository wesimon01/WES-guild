using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarDealership.Models;
using CarDealership.BLL;

namespace CarDealership.UI.Controllers
{
    public class MicroController : ApiController
    {
        IDealershipService _service;

        public MicroController(IDealershipService service)
        {
            _service = service;
        }

        public void Delete(int id)
        {
            _service.RemoveVehicle(id);
        }

    }
}
