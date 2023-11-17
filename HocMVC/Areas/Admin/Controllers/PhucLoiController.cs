using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class PhucLoiController : BaseController
    {
        // GET: Admin/PhucLoi
        // GET: Admin/PhucLoi
        public ActionResult Index()
        {

            var dao = new PhucLoiDao();
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
        public ActionResult Create(PhucLoi PhucLoi, IEnumerable<HttpPostedFileBase> myFiles)
        {

            if (ModelState.IsValid)
            {
                var dao = new PhucLoiDao();
                var ngaynhap = DateTime.Now;
                PhucLoi.CreatedDate = ngaynhap;
                long ID = dao.Insert(PhucLoi);
                SetAlert("Thêm thành công", "success");
                //SetViewbag();
            }
            return RedirectToAction("Index", "PhucLoi");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PhucLoi model)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhucLoiDao();
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return RedirectToAction("Index", "PhucLoi");
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
            var dao = new PhucLoiDao();
            var PhucLoi = dao.GetbyID(id);
            return View(PhucLoi);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new PhucLoiDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PhucLoiDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}