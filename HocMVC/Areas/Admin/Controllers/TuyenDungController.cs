using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class TuyenDungController : BaseController
    {
        // GET: Admin/TuyenDung
        Mystring mystr = new Mystring();
        public ActionResult Index()
        {
            var dao = new TuyenDungDao();
            var model = dao.ListAllAdm();
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
        public ActionResult Create(TuyenDung TuyenDung, IEnumerable<HttpPostedFileBase> myFiles)
        {

            if (ModelState.IsValid)
            {
                var dao = new TuyenDungDao();
                var ngaynhap = DateTime.Now;
                TuyenDung.CreatedDate = ngaynhap;
                TuyenDung.ModifiedDate = DateTime.Now;
                long ID = dao.Insert(TuyenDung);
                SetAlert("Thêm vị trí thành công", "success");
                //SetViewbag();
            }
            return RedirectToAction("Index", "Project");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TuyenDung model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TuyenDungDao();
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật vị trí tuyển dụng thành công", "success");
                    return RedirectToAction("Index", "TuyenDung");
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
            var dao = new TuyenDungDao();
            var TuyenDung = dao.ViewDetail(id);
            return View(TuyenDung);
        }
        //[HttpPost]
        //public void SetViewbag(long? selectedId = null)
        //{
        //    var dao = new LoaiTuyenDungDao();
        //    ViewBag.LoaiTuyenDung = new SelectList(dao.ListAll(), "iD", "TenLoaiTuyenDung", selectedId);
        //}
        public JsonResult ChangeStatus(long id)
        {
            var result = new TuyenDungDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new TuyenDungDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}