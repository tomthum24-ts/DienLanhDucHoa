using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class QuanLyController :   BaseController
    {
        // GET: Admin/QuanLy
        public ActionResult Index()
        {
            var dao = new QuanLyDao();
            var model = dao.ListAdmin();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new QuanLy();
            model.GioiTinh = true;
            SetViewbag();
            SetViewbagCongTy();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(QuanLy QuanLy)
        {

            if (ModelState.IsValid)
            {
                var dao = new QuanLyDao();
                long ID = dao.Insert(QuanLy);
                SetAlert("Thêm vị trí thành công", "success");
                //SetViewbag();
            }
            return RedirectToAction("Index", "QuanLy");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(QuanLy model)
        {
            if (ModelState.IsValid)
            {
               
                var dao = new QuanLyDao();
                SetViewbag(model.IdPhanLoai);
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật vị trí tuyển dụng thành công", "success");
                    return RedirectToAction("Index", "QuanLy");
                }
                else
                {
                    SetAlert("Cập nhật thất bại", "alert-danger");
                    ModelState.AddModelError("", "cập nhật vị trí tuyển dụng thất bại");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            SetViewbag();
            SetViewbagCongTy();
            var dao = new QuanLyDao();
            var QuanLy = dao.ViewDetail(id);
            return View(QuanLy);
        }
        [HttpPost]
        public void SetViewbag(long? selectedId = null)
        {
            var dao = new PhanLoaiQuanLyDao();
            ViewBag.IdPhanLoai = new SelectList(dao.ListAll(), "ID", "TenPhanLoai", selectedId);
        }
        [HttpPost]
        public void SetViewbagCongTy(long? selectedId = null)
        {
            var dao = new CongTyQuanLyDao();
            ViewBag.IdCongTy = new SelectList(dao.ListAll(), "Id", "TenCongTy", selectedId);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new QuanLyDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new QuanLyDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}