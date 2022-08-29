using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiThuyKieu_1.Context;
using NguyenThiThuyKieu_1.Models;

namespace NguyenThiThuyKieu_1.Controllers
{
    public class PaymentController : Controller
    {
        QuanLyBanHangEntities3 objquanLyBanHangEntities3 = new QuanLyBanHangEntities3();

        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                //gan du lieu cho bang Order
                Order objOrder = new Order();
                objOrder.Name = "DonHang" + DateTime.Now.ToString("ddMMyyyyHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                objquanLyBanHangEntities3.Orders.Add(objOrder);
                //luu vao bang Order
                objquanLyBanHangEntities3.SaveChanges();
                //Lay OrderId vua tao luu vao bang OrderDetail
                int intOrderId = objOrder.Id;

                List<OrderDetail> lstOrderDetail = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                objquanLyBanHangEntities3.OrderDetails.AddRange(lstOrderDetail);
                objquanLyBanHangEntities3.SaveChanges();
            }
            return View();
        }
    }
}