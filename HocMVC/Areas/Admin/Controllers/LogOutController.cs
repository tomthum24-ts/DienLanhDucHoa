using HocMVC.Areas.Admin.Models;
using HocMVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class LogOutController : BaseController
    {
        // GET: Admin/LogOut
        public ActionResult Index()
        {
            Session.Add(SessionKT.USER_SESSION, null);
            return Redirect("Login");
        }
        public ActionResult LogOut(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Session.Add(SessionKT.USER_SESSION, null);
            }
            return View("Index");

        }
    }
}