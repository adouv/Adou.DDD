using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adou.AuthManage.Areas.AdouManage.Controllers
{
    public class AppController : Controller
    {
        // GET: AdouManage/App
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Content()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
    }
}