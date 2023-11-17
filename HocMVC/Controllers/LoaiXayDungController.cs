using Model.Dao;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class LoaiXayDungController : Controller
    {
        // GET: LoaiXayDung
        public ActionResult Category(int id = 0)
        {
            var category = new LoaiXayDungDao().GetbyID(id);
            ViewBag.XayDung = new LoaiXayDungDao().ListAll();
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.XayDung);
            return View(category);
        }

    }
}