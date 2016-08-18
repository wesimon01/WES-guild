using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DVDLibrary.Models;
using DVDLibrary.BLL;


namespace DVDLibrary.UI
{
    public class WebApiController : ApiController
    {
        IDVDService _service;
   
        public WebApiController(IDVDService service)
        {
            _service = service;
        }

        public DVD Get(string st)
        {
            return _service.GetDVDbyTitle(st);
        }
 
    }
}