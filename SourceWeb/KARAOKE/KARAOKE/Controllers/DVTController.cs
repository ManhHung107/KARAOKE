using KARAOKE.Models.Dao;
using KARAOKE.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KARAOKE.Controllers
{
    public class DVTController : BaseController
    {
        // GET: DVT
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DVTDao();
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
        public ActionResult Create(DonViTinh dvt)
        {
            if (ModelState.IsValid)
            {
                var dao = new DVTDao();
                long id = dao.Insert(dvt);
                if (id > 0)
                {
                    return RedirectToAction("Index", "DVT");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm đơn vị tính thành công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dvt = new DVTDao().ViewDetail(id);
            return View(dvt);
        }
        [HttpPost]
        public ActionResult Edit(DonViTinh dvt)
        {
            if (ModelState.IsValid)
            {
                var dao = new DVTDao();
                var result = dao.Update(dvt);
                if (result)
                {
                    return RedirectToAction("Index", "DVT");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật đơn vị tính thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DVTDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}