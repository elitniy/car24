using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using car24project.Models;

namespace car24project.Areas.Cingo.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Cingo/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}