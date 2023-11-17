using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class HotLineController : BaseController
    {
        // GET: Admin/HotLine
        public ActionResult Index()
        {

            var dao = new HotLineDao();
            var model = dao.ListAllPagingAd();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //SetViewbag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(HotLine HotLine, IEnumerable<HttpPostedFileBase> myFiles)
        {

            if (ModelState.IsValid)
            {
                var dao = new HotLineDao();
                var ngaynhap = DateTime.Now;
                long ID = dao.Insert(HotLine);
                SetAlert("Thêm thành công", "success");
                //SetViewbag();
            }
            return RedirectToAction("Index", "HotLine");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(HotLine model)
        {
            if (ModelState.IsValid)
            {
                var dao = new HotLineDao();
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return RedirectToAction("Index", "HotLine");
                }
                else
                {
                    SetAlert("Cập nhật thất bại", "alert-danger");
                    ModelState.AddModelError("", "cập nhật thất bại");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new HotLineDao();
            var HotLine = dao.GetbyID(id);
            return View(HotLine);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new HotLineDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new HotLineDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}