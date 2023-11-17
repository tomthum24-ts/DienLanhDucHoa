using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class NhanSuController : Controller
    {
        // GET: Admin/NhanSu
        public ActionResult Index()
        {
            return View();
        }
    }
}