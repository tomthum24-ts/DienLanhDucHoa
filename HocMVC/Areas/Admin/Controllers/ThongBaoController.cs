using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class ThongBaoController : BaseController
    {
        // GET: Admin/ThongBao
        Mystring mystr = new Mystring();
        public ActionResult Index()
        {
            var dao = new QuangCaoDao();
            var model = dao.ListAllAdmin();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(QuangCao model)
        {
            if (ModelState.IsValid)
            {
                var dao = new QuangCaoDao();
                var result = dao.Update(model);

                if (result)
                {
                    SetAlert("cập nhật bài viết thành công", "success");
                    return RedirectToAction("Index", "ThongBao");
                }
                else
                {
                    SetAlert("Thêm user thành công", "alert-danger");
                    ModelState.AddModelError("", "cập nhật không user thành công");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new QuangCaoDao();
            var QuangCao = dao.GetbyID(id);
            return View(QuangCao);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(QuangCao QuangCao)
        {

            if (ModelState.IsValid)
            {

                var dao = new QuangCaoDao();
                long ID = dao.Insert(QuangCao);
                SetAlert("Thêm tin tức thành công", "success");

            }
            else
            {
                SetAlert("Thêm tin tức không thành công", "error");
            }

            return RedirectToAction("Index", "QuangCao");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new QuangCaoDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new QuangCaoDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}