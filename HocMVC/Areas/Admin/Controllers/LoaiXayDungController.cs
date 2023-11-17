using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class LoaiXayDungController : BaseController
    {
        // GET: Admin/LoaiXayDungProject
        Mystring mystr = new Mystring();
        public async Task<ActionResult> Index()
        {
            var dao = new LoaiXayDungDao();
            var content = await dao.ListAllPagingAd();
            return View(content);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new LoaiXayDungDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(LoaiXayDung LoaiXayDung)
        {

            if (ModelState.IsValid)
            {
                var ngaynhap = DateTime.Now;
                var dao = new LoaiXayDungDao();
                long ID = dao.Insert(LoaiXayDung);
                LoaiXayDung.Status = true;
                LoaiXayDung.MetaTitle = mystr.ToVietAlias(LoaiXayDung.MetaTitle);

                var result = dao.Update(LoaiXayDung);
                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index", "LoaiXayDung");
            }
            else
            {
                SetAlert("Cập nhật  không thành công", "error");
                ModelState.AddModelError("", "cập nhật không thành công");
            }

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(LoaiXayDung model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiXayDungDao();
                model.MetaTitle = mystr.ToVietAlias(model.MetaTitle);
                var result = dao.Update(model);

                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return RedirectToAction("Index", "LoaiXayDung");
                }
                else
                {
                    SetAlert("Cập nhật  không thành công", "alert-danger");
                    ModelState.AddModelError("", "cập nhật không thành công");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new LoaiXayDungDao();
            var content = dao.GetbyID(id);
            return View(content);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LoaiXayDungDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}