using Model.Dao;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class AmThucController : Controller
    {
        // GET: AmThuc
        public ActionResult Index(long id = 0)
        {
            var model = new AmThucDao();
            var data = model.ViewDetail(id);
            ViewBag.loaiAmThuc= data.Id;
            var AmThuc = model.ListAll();
            ViewBag.AmThuc = AmThuc;
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.AmThuc);
            return View(data);
        }
    }
}