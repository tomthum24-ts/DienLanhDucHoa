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
    public class ProjectController : BaseController
    {
        // GET: Admin/Project
        Mystring mystr = new Mystring();
        public ActionResult Index()
        {
            var dao = new DuAnDao();
            var model = dao.ListAllAdmin();
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
        public ActionResult Create(DuAn DuAn, IEnumerable<HttpPostedFileBase> imageUploader)
        {
            var duongDan = "~/Public/Images/images";
            if (ModelState.IsValid)
            {
                List<BoiCanh> listImage = new List<BoiCanh>();
                
                DuAn.MetaTitle = mystr.ToVietAlias(DuAn.MetaTitle);
                var ngaynhap = DateTime.Now;
                DuAn.CreatedDate = ngaynhap;
                DuAn.ModifiedDate = DateTime.Now;
                DuAn.MetaTitle = mystr.ToVietAlias(DuAn.MetaTitle);
                var imageBoiCanh = new BoiCanh();
                var daoDuAn = new DuAnDao();
                long ID = daoDuAn.Insert(DuAn);
                if(imageUploader != null || imageUploader.Count()>0)
                foreach (var file in imageUploader)
                {
                    
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath(duongDan), fileName);
                        file.SaveAs(path);
                        imageBoiCanh.Image = "../Public/Images/images/" + fileName;
                        imageBoiCanh.IdDuAn = (int)ID;
                        imageBoiCanh.CreatedDate = DateTime.Now;
                        imageBoiCanh.ModifiedDate = DateTime.Now;
                        imageBoiCanh.Status = true;
                         long insert = new BoiCanhDao().Insert(imageBoiCanh);
                        }
                    //listImage.Add(imageBoiCanh);
                   
                }                
                //var result = dao.Update(content);
                SetAlert("Thêm dự án thành công", "success");
                SetViewbag();
            }
            else
            {
                SetAlert("Kiểm tra lại thông tin", "error");
                SetViewbag();
                return View(DuAn);
            }
            
            return RedirectToAction("Index", "Project");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DuAn model, IEnumerable<HttpPostedFileBase> imageUploader)
        {
            var duongDan = "~/Public/Images/images";
            if (ModelState.IsValid)
            {
                var dao = new DuAnDao();
                model.MetaTitle = mystr.ToVietAlias(model.MetaTitle);
                var result = dao.Update(model);
                var imageBoiCanh = new BoiCanh();
                if (imageUploader != null || imageUploader.Count() > 0)
                     new BoiCanhDao().DeleteAll(model.Id);
                    foreach (var file in imageUploader)
                    {

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath(duongDan), fileName);
                            file.SaveAs(path);
                            imageBoiCanh.Image = "../Public/Images/images/" + fileName;
                            imageBoiCanh.IdDuAn = model.Id;
                            imageBoiCanh.CreatedDate = DateTime.Now;
                            imageBoiCanh.ModifiedDate = DateTime.Now;
                            imageBoiCanh.Status = true;
                            long insert = new BoiCanhDao().Insert(imageBoiCanh);
                        }
                    }
                SetViewbag(model.LoaiDuAn);
                if (result)
                {

                    SetAlert("cập nhật dự án thành công", "success");
                    return RedirectToAction("Index", "Project");
                }
                else
                {
                    
                    SetAlert("Cập nhật thất bại", "alert-danger");
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
            var dao = new DuAnDao();
            var DuAn = dao.ViewDetail(id);
            SetViewbag(DuAn.LoaiDuAn);
            return View(DuAn);
        }
        [HttpPost]
        public  void SetViewbag(long? selectedId = null)
        {
            var dao = new LoaiDuAnDao();
            ViewBag.LoaiDuAn = new SelectList( dao.ListAll(), "iD", "TenLoaiDuAn", selectedId);
        }
        public JsonResult ChangeStatus(long id)
        {
            var result = new DuAnDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DuAnDao().Delete(id);
            return RedirectToAction("Index");

        }
    }
}