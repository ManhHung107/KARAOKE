using KARAOKE.Models.Dao;
using KARAOKE.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace KARAOKE.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create(string name)
        {
            KaraokeDbContext context = new KaraokeDbContext();
            MatHang objCourse = new MatHang();
            objCourse.listDVT = context.DonViTinh.ToList();
            return View(objCourse);
        }
        [HttpPost]
        public ActionResult Create(MatHang product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mặt hàng thành công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            KaraokeDbContext context = new KaraokeDbContext();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }    
            MatHang x = context.MatHang.FirstOrDefault(m=>m.ID==id);
            x.listDVT = context.DonViTinh.ToList();
            if(x==null)
            {
                return HttpNotFound();
            }    
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(MatHang product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật mặt hàng thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}