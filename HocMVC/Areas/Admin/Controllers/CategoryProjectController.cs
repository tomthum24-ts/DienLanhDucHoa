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
    public class CategoryProjectController : BaseController
    {
        // GET: Admin/LoaiDuAnProject
        Mystring mystr = new Mystring();
        public async Task<ActionResult> Index()
        {
            var dao = new LoaiDuAnDao();
            var content = await dao.ListAllPagingAd();
            return View(content);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new LoaiDuAnDao().ChangeStatus(id);
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
        public ActionResult Create(LoaiDuAn LoaiDuAn)
        {

            if (ModelState.IsValid)
            {
                var ngaynhap = DateTime.Now;
                var dao = new LoaiDuAnDao();
                long ID = dao.Insert(LoaiDuAn);
                LoaiDuAn.Status = true;
                LoaiDuAn.MetaTitle = mystr.ToVietAlias(LoaiDuAn.MetaTitle);

                var result = dao.Update(LoaiDuAn);
                SetAlert("Thêm thành công", "success");
            }

            return RedirectToAction("Index", "CategoryProject");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(LoaiDuAn model)
        {
            if (ModelState.IsValid)
            {
                var dao = new LoaiDuAnDao();
                model.MetaTitle = mystr.ToVietAlias(model.MetaTitle);
                var result = dao.Update(model);

                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return RedirectToAction("Index", "CategoryProject");
                }
                else
                {
                    SetAlert("Cập nhật  không thành công", "error");
                    ModelState.AddModelError("", "cập nhật  không thành công");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new LoaiDuAnDao();
            var content = dao.GetbyID(id);
            return View(content);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new LoaiDuAnDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}