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
    public class PhongController : Controller
    {
        // GET: Phong
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new PhongDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            KaraokeDbContext context = new KaraokeDbContext();
            Phong objCourse = new Phong();
            objCourse.listLoaiPhong = context.LoaiPhong.ToList();
            return View(objCourse);
        }
        [HttpPost]
        public ActionResult Create(Phong p)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhongDao();
                long id = dao.Insert(p);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Phong");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phòng thành công");
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
            Phong x = context.Phong.FirstOrDefault(m => m.ID == id);
            x.listLoaiPhong = context.LoaiPhong.ToList();
            if (x == null)
            {
                return HttpNotFound();
            }
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(Phong p)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhongDao();
                var result = dao.Update(p);
                if (result)
                {
                    return RedirectToAction("Index", "Phong");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phòng thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PhongDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}