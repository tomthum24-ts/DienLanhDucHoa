using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class AmThucController : BaseController
    {
        // GET: Admin/AmThuc
        Mystring mystr = new Mystring();
        public ActionResult Index()
        {
            var dao = new AmThucDao();
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
        public ActionResult Create(AmThuc amThuc)
        {

            if (ModelState.IsValid)
            {
                var dao = new AmThucDao();
                var ngaynhap = DateTime.Now;
                amThuc.MetaTitle = mystr.ToVietAlias(amThuc.MetaTitle);
                amThuc.CreatedDate = ngaynhap;
                amThuc.ModifiedDate = DateTime.Now;
                long ID = dao.Insert(amThuc);
                SetAlert("Thêm thành công", "success");
                //SetViewbag();
            }
            return RedirectToAction("Index", "AmThuc");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(AmThuc model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AmThucDao();
                model.MetaTitle = mystr.ToVietAlias(model.MetaTitle);
                var result = dao.Update(model);
                //SetViewbag();
                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return RedirectToAction("Index", "AmThuc");
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
            var dao = new AmThucDao();
            var AmThuc = dao.ViewDetail(id);
            return View(AmThuc);
        }
        //[HttpPost]
        //public void SetViewbag(long? selectedId = null)
        //{
        //    var dao = new LoaiAmThucDao();
        //    ViewBag.LoaiAmThuc = new SelectList(dao.ListAll(), "iD", "TenLoaiAmThuc", selectedId);
        //}
        public JsonResult ChangeStatus(long id)
        {
            var result = new AmThucDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AmThucDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}