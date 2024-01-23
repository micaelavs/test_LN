using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace proyectoApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("home")]
        public IHttpActionResult Index()
        {

            return Ok(new { mensaje = "¡Bienvenido a la API!" });
        }
    }
}
