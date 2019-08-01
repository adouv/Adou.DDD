using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adou.AuthManage.Areas.AdouManage.Controllers
{
    public class BaseController : Controller
    {
        // GET: AdouManage/Base
        public ActionResult Index()
        {
            return View();
        }
    }
}