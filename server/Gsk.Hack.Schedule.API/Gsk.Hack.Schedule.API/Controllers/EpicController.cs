using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gsk.Hack.Schedule.API.Controllers
{
    [RoutePrefix("api/epic")]
    public class EpicController : ApiController
    {
        [HttpGet]
        [Route]
        [Route("code")]
        public IHttpActionResult Code([FromUri]string code)
        {
            return Ok();
        }
    }
}
