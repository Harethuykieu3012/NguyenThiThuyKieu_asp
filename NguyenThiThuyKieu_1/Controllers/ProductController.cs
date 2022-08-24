using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiThuyKieu_1.Context;

namespace NguyenThiThuyKieu_1.Controllers
{
    public class ProductController : Controller
    {
        QuanLyBanHangEntities3 objquanLyBanHangEntities3 = new QuanLyBanHangEntities3();
        // GET: Product
        public ActionResult Detail (int Id)
        {
            var objProduct = objquanLyBanHangEntities3.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}