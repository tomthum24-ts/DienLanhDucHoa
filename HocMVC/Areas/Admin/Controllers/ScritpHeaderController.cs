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
    public class ScritpHeaderController : BaseController
    {
        // GET: Admin/ScritpHeader
        Mystring mystr = new Mystring();
        public async Task<ActionResult> Index()
        {
            var dao = new ScritpHeaderDao();
            var content = await dao.ListAllPagingAd();
            return View(content);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new ScritpHeaderDao().ChangeStatus(id);
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
        public ActionResult Create(ScritpHeader ScritpHeader)
        {

            if (ModelState.IsValid)
            {
             
                var dao = new ScritpHeaderDao();
                long ID = dao.Insert(ScritpHeader);

                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index", "ScritpHeader");
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
        public ActionResult Edit(ScritpHeader model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ScritpHeaderDao();
                var result = dao.Update(model);

                if (result)
                {
                    SetAlert("cập nhật thành công", "success");
                    return RedirectToAction("Index", "ScritpHeader");
                }
                else
                {
                    SetAlert("Cập nhật  không thành công", "error");
                    ModelState.AddModelError("", "cập nhật không thành công");
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ScritpHeaderDao();
            var content = dao.GetbyID(id);
            return View(content);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ScritpHeaderDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}