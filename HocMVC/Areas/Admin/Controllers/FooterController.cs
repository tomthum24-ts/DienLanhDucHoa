using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        // GET: Admin/Footer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Footer model)
        {
            if (ModelState.IsValid)
            {

                var dao = new FooterDao();
      
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return View();
                }
                else
                {
                    SetAlert("Cập nhật thất bại", "alert-danger");
                    ModelState.AddModelError("", "cập nhật  thất bại");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new FooterDao();
            var Footer = dao.ViewDetail(id);
            return View(Footer);
        }
    }
}