using Model.Dao;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.GioiThieu);
            var aboutUS=  new AboutDao().GetAbout();
            ViewBag.AboutUs= aboutUS;
            return View();
        }
    }
}