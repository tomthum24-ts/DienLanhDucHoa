using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class ViTriTuyenDungController : BaseController
    {
        // GET: Admin/ViTriTuyenDung
        Mystring mystr = new Mystring();
        public ActionResult Index()
        {
            var dao = new ViTriTuyenDungDao();
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
        public ActionResult Create(ViTriTuyenDung ViTriTuyenDung, IEnumerable<HttpPostedFileBase> myFiles)
        {

            if (ModelState.IsValid)
            {
                var dao = new ViTriTuyenDungDao();
                var ngaynhap = DateTime.Now;
                ViTriTuyenDung.CreatedDate = ngaynhap;
                ViTriTuyenDung.ModifiedDate = DateTime.Now;
                long ID = dao.Insert(ViTriTuyenDung);
                SetAlert("Thêm vị trí thành công", "success");
                //SetViewbag();
            }
            return RedirectToAction("Index", "Project");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ViTriTuyenDung model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ViTriTuyenDungDao();
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật vị trí tuyển dụng thành công", "success");
                    return RedirectToAction("Index", "ViTriTuyenDung");
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
            var dao = new ViTriTuyenDungDao();
            var ViTriTuyenDung = dao.ViewDetail(id);
            return View(ViTriTuyenDung);
        }
        //[HttpPost]
        //public void SetViewbag(long? selectedId = null)
        //{
        //    var dao = new LoaiViTriTuyenDungDao();
        //    ViewBag.LoaiViTriTuyenDung = new SelectList(dao.ListAll(), "iD", "TenLoaiViTriTuyenDung", selectedId);
        //}
        public JsonResult ChangeStatus(long id)
        {
            var result = new ViTriTuyenDungDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ViTriTuyenDungDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}