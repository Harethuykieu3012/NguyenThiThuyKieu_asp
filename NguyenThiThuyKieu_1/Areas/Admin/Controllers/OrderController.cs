using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiThuyKieu_1.Context;

namespace NguyenThiThuyKieu_1.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        QuanLyBanHangEntities3 objquanLyBanHangEntities3 = new QuanLyBanHangEntities3();
        public ActionResult Index()
        {
            var listOrder = objquanLyBanHangEntities3.Orders.ToList();
            return View(listOrder);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = objquanLyBanHangEntities3.Orders.Where(n => n.Id == id).FirstOrDefault();
            return View(order);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var objorder = objquanLyBanHangEntities3.Orders.Where(n => n.Id == Id).FirstOrDefault();

            return View(objorder);
        }
        [HttpPost]
        public ActionResult Delete(Order objor)
        {

            var objorder = objquanLyBanHangEntities3.Orders.Where(n => n.Id == objor.Id).FirstOrDefault();
            objquanLyBanHangEntities3.Orders.Remove(objorder);
            objquanLyBanHangEntities3.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}