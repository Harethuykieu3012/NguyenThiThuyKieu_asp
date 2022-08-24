using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiThuyKieu_1.Context;

namespace NguyenThiThuyKieu_1.Controllers
{
    public class CategoryController : Controller
    {
        QuanLyBanHangEntities3 objquanLyBanHangEntities3 = new QuanLyBanHangEntities3();

        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = objquanLyBanHangEntities3.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listCategory = objquanLyBanHangEntities3.Products.Where(n => n.CategoryId == Id).ToList();
            return View(listCategory);
        }
    }
}