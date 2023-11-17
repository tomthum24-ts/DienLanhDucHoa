using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(int page = 1, int pageSize = 1000)
        {
            var dao = new SlideDao();
            var model = dao.ListAllPagingAd(page, pageSize);
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
        public ActionResult Create(Slide slide)
        {

            if (ModelState.IsValid)
            {
                var ngaynhap = DateTime.Now;
                slide.CreatedDate = ngaynhap;
                var dao = new SlideDao();
                
                long ID = dao.Insert(slide);
                if (slide.Status == false)
                {
                    slide.Status = true;
                }
                else
                {
                    slide.Status = false;
                }
                //var result = dao.Update(content);
                SetAlert("Thêm sản phẩm thành công", "success");
            }

            return RedirectToAction("Index", "Slide");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Slide model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();
                var result = dao.Update(model);
                if (result)
                {
                    SetAlert("cập nhật slide thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    SetAlert("Thêm user thành công", "alert-danger");
                    ModelState.AddModelError("", "cập nhật slide không thành công");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new SlideDao();
            var content = dao.GetbyID(id);
            SetViewbag(content.IDCategory);
            return View(content);
        }
        public void SetViewbag(long? selectedId = null)
        {
            var dao = new CategorySlideDao();
            ViewBag.IDCategory = new SelectList(dao.ListAll(), "Id", "TenLoaiSlide", selectedId);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new SlideDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SlideDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}