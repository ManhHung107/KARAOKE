using KARAOKE.Models.Dao;
using KARAOKE.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KARAOKE.Controllers
{
    public class NCCController : BaseController
    {
        // GET: NCC
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new NCCDao();
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
        public ActionResult Create(NCC nc)
        {
            if (ModelState.IsValid)
            {
                var dao = new NCCDao();
                long id = dao.Insert(nc);
                if (id > 0)
                {
                    return RedirectToAction("Index", "NCC");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhà cung cấp thành công");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ncc = new NCCDao().ViewDetail(id);
            return View(ncc);
        }
        [HttpPost]
        public ActionResult Edit(NCC ncc)
        {
            if (ModelState.IsValid)
            {
                var dao = new NCCDao();
                var result = dao.Update(ncc);
                if (result)
                {
                    return RedirectToAction("Index", "NCC");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật nhà cung cấp thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new NCCDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}