using KARAOKE.Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KARAOKE.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        public ActionResult Index()
        {
            DateTime tuNgay = DateTime.Parse("01/01/2019 00:00");
            DateTime toiNgay = DateTime.Parse("01/01/2022 00:00");
            var dao = new ThongKeDao();
            var model = dao.ThongKePhong(tuNgay, toiNgay);
            return View(model);
        }
    }
}