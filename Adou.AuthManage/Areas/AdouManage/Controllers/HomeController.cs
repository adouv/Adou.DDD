using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adou.AuthManage.Areas.AdouManage.Controllers
{
    public class HomeController : Controller
    {
        // GET: AdouManage/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Template()
        {
            return View();
        }
    }
}