using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Gsk.Hack.Schedule.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult EpicCode([FromUri]string code)
        {
            Cache.AuthToken.Instance().SetCode(code);

            ViewBag.Code = code;

            return View();
        }
    }
}
