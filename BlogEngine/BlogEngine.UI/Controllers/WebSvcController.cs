using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogEngine.Models;
using BlogEngine.BLL;
using System.IO;


namespace BlogEngine.UI.Controllers
{
    public class WebSvcController : ApiController
    {
        IBlogEngineService _service;

        public WebSvcController(IBlogEngineService service)
        {
            _service = service;
        }

        public List<Blogpost> Get(string id)
        {
            return _service.GetPostsbyHashTagName(id);
        }

        //public string[] Get()
        //{
        //    return Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~/Content/"));

        //}
    }
}

