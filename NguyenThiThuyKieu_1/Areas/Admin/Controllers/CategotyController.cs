using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NguyenThiThuyKieu_1.Context;
using NguyenThiThuyKieu_1.Models;
using static NguyenThiThuyKieu_1.Common;

namespace NguyenThiThuyKieu_1.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        QuanLyBanHangEntities3 objquanLyBanHangEntities3 = new QuanLyBanHangEntities3();
        //GET: Admin/Category

        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstCategory = new List<Category>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstCategory = objquanLyBanHangEntities3.Categories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstCategory = objquanLyBanHangEntities3.Categories.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstCategory = lstCategory.OrderByDescending(n => n.Id).ToList();
            return View(lstCategory.ToPagedList(pageNumber, pageSize));
        }



        void LoadData()
        {
            Common objCommon = new Common();
            // lấy dữ liệu dưới db
            var lstCat = objquanLyBanHangEntities3.Categories.ToList();
            //convert  sang select list dạng value,text
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dtCategory = converter.ToDataTable(lstCat);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "Id", "Name");
            // lấy dữ diệu thương hiệu dưới db
            var lstBrand = objquanLyBanHangEntities3.Brands.ToList();
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            //convert sang select list dang value, text
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "Id", "Name");
            //typeoid
            List<CategoryType> lstCategoryType = new List<CategoryType>();
            CategoryType objCategoryType = new CategoryType();
            objCategoryType.Id = 01;
            objCategoryType.Name = "Giảm giá sốc";
            lstCategoryType.Add(objCategoryType);

            objCategoryType = new CategoryType();
            objCategoryType.Id = 02;
            objCategoryType.Name = "Đề xuất";
            lstCategoryType.Add(objCategoryType);

            DataTable dtCategoryType = converter.ToDataTable(lstCategoryType);
            ViewBag.CategoryType = objCommon.ToSelectList(dtCategoryType, "Id", "Name");


        }
        [HttpGet]
        public ActionResult Create()
        {
            //lay du lieu
            this.LoadData();
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category objCategory)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {

                    if (objCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                        //tenhinh
                        string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                        //png
                        fileName = fileName + extension;
                        //tenhinh.png
                        objCategory.Avatar = fileName;
                        objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));
                    }

                    objCategory.CreatedOnUtc = DateTime.Now;
                    objquanLyBanHangEntities3.Categories.Add(objCategory);
                    objquanLyBanHangEntities3.SaveChanges();

                    return RedirectToAction("Index");
                }

                catch
                {
                    return View(objCategory);
                }

            }
            return View(objCategory);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objCategory = objquanLyBanHangEntities3.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCategory = objquanLyBanHangEntities3.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }

        [HttpPost]
        public ActionResult Delete(Category objPro)
        {
            var objCategory = objquanLyBanHangEntities3.Categories.Where(n => n.Id == objPro.Id).FirstOrDefault();

            objquanLyBanHangEntities3.Categories.Remove(objCategory);
            objquanLyBanHangEntities3.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]


        public ActionResult Edit(int id)
        {
            this.LoadData();
            var objCategory = objquanLyBanHangEntities3.Categories.Where(n => n.Id == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category objCategory, FormCollection form)
        {
            
            if (objCategory.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                //tenhinh
                string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                //png
                fileName = fileName + extension;
                //tenhinh.png
                objCategory.Avatar = fileName;
                objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items"), fileName));

            }
            else
            {
                objCategory.Avatar = form["oldimage"];
                objquanLyBanHangEntities3.Entry(objCategory).State = EntityState.Modified;
                objquanLyBanHangEntities3.SaveChanges();
                return RedirectToAction("Index");
            }
            objquanLyBanHangEntities3.Entry(objCategory).State = EntityState.Modified;
            objquanLyBanHangEntities3.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}