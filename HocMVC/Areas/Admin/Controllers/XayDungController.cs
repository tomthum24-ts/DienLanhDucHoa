using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class XayDungController : BaseController
    {
        // GET: Admin/Project
        Mystring mystr = new Mystring();
        public ActionResult Index()
        {
            var dao = new XayDungDao();
            var model = dao.ListAllAdm();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewbag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(XayDung xayDung, IEnumerable<HttpPostedFileBase> imageUploader)
        {
            var duongDan = "~/Public/Images/images";
            if (ModelState.IsValid)
            {
                List<BoiCanh> listImage = new List<BoiCanh>();

                xayDung.MetaTitle = mystr.ToVietAlias(xayDung.MetaTitle);
                var ngaynhap = DateTime.Now;
                xayDung.CreatedDate = ngaynhap;
                xayDung.ModifiedDate = DateTime.Now;
                xayDung.MetaTitle = mystr.ToVietAlias(xayDung.MetaTitle);
                var imageBoiCanh = new BoiCanh();
                var daoXayDung = new XayDungDao();
                long ID = daoXayDung.Insert(xayDung);
               
                SetAlert("Thêm dự án thành công", "success");
                SetViewbag();
            }
            else
            {
                SetAlert("Kiểm tra lại thông tin", "error");
                SetViewbag();
                return View(xayDung);
            }

            return RedirectToAction("Index", "XayDung");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(XayDung model, IEnumerable<HttpPostedFileBase> imageUploader)
        {
            var duongDan = "~/Public/Images/images";
            if (ModelState.IsValid)
            {
                var dao = new XayDungDao();
                model.MetaTitle = mystr.ToVietAlias(model.MetaTitle);
                var result = dao.Update(model);
                var imageBoiCanh = new BoiCanh();
                SetViewbag(model.LoaiDuAn);
                if (result)
                {

                    SetAlert("cập nhật dự án thành công", "success");
                    return RedirectToAction("Index", "XayDung");
                }
                else
                {

                    SetAlert("Cập nhật thất bại", "error");
                    ModelState.AddModelError("", "cập nhật dự án thất bại");
                    return View(model);
                }
            }
            SetViewbag(model.LoaiDuAn);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new XayDungDao();
            var XayDung = dao.ViewDetail(id);
            SetViewbag(XayDung.LoaiDuAn);
            return View(XayDung);
        }
        [HttpPost]
        public void SetViewbag(long? selectedId = null)
        {
            var dao = new LoaiXayDungDao();
            ViewBag.LoaiDuAn = new SelectList(dao.ListAll(), "iD", "TenLoaiDuAn", selectedId);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new XayDungDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new XayDungDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}