using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NguyenThiThuyKieu_1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Address()
        {
            return View();
        }
        public ActionResult Orders()
        {
            return View();
        }


    }
}