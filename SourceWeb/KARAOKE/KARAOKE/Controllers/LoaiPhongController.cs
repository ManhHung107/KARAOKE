using KARAOKE.Models.Dao;
using KARAOKE.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KARAOKE.Controllers
{
    public class LoaiPhongController : Controller
    {
        // GET: LoaiPhong
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new LoaiPhongDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiPhong lp)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiPhongDao();
                long id = dao.Insert(lp);
                if (id > 0)
                {
                    return RedirectToAction("Index", "LoaiPhong");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm loại phòng thành công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lp = new LoaiPhongDao().ViewDetail(id);
            return View(lp);
        }
        [HttpPost]
        public ActionResult Edit(LoaiPhong lp)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiPhongDao();
                var result = dao.Update(lp);
                if (result)
                {
                    return RedirectToAction("Index", "LoaiPhong");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật loại phòng thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LoaiPhongDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}