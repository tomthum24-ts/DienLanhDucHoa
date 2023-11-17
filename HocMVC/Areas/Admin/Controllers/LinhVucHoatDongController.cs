using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class LinhVucHoatDongController : BaseController
    {
        // GET: Admin/LinhVucHoatDong
        public ActionResult Index()
        {

            var dao = new LinhVucHoatDongDao();
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
        public ActionResult Create(LinhVucHoatDong LinhVucHoatDong, IEnumerable<HttpPostedFileBase> myFiles)
        {

            if (ModelState.IsValid)
            {
                var dao = new LinhVucHoatDongDao();
                var ngaynhap = DateTime.Now;
                LinhVucHoatDong.CreatedDate = ngaynhap;
                LinhVucHoatDong.ModifiedDate = DateTime.Now;
                long ID = dao.Insert(LinhVucHoatDong);
                SetAlert("Thêm thành công", "success");
                //SetViewbag();
                return RedirectToAction("Index", "LinhVucHoatDong");
            }
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(LinhVucHoatDong model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LinhVucHoatDongDao();
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return RedirectToAction("Index", "LinhVucHoatDong");
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
            var dao = new LinhVucHoatDongDao();
            var LinhVucHoatDong = dao.GetbyID(id);
            return View(LinhVucHoatDong);
        }
        //[HttpPost]
        //public void SetViewbag(long? selectedId = null)
        //{
        //    var dao = new LoaiLinhVucHoatDongDao();
        //    ViewBag.LoaiLinhVucHoatDong = new SelectList(dao.ListAll(), "iD", "TenLoaiLinhVucHoatDong", selectedId);
        //}
        public JsonResult ChangeStatus(long id)
        {
            var result = new LinhVucHoatDongDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LinhVucHoatDongDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}