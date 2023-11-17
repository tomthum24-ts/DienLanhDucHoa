using HocMVC.Common;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
       ShopDbContext DbContext = new ShopDbContext();
        // GET: Admin/User
        public ActionResult Index(int page=1,int pageSize=100)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var user = new UserDao().viewDetail(id);
            return View(user);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                bool existing = DbContext.Users.Any(x => x.UserName == user.UserName);
                if(existing || string.IsNullOrEmpty(user.UserName))
                {
                    SetAlert("User đã tồn tại trong hệ thống", "error");
                    ModelState.AddModelError("", "User đã tồn tại trong hệ thống");
                    return View(user);
                }
                var encrypt = Encryptor.MD5Hash(user.Password ?? user.UserName);
                var ngaynhap = DateTime.Now;
                user.CreatedDate = ngaynhap;
                
                var dao = new UserDao();
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Thêm user không thành công", "error");
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View(user);

        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            { 
                if (!string.IsNullOrEmpty(user.Password))
                {
                    var encrypt = Encryptor.MD5Hash(user.Password);
                    user.Password = encrypt;
                }               
                user.CreatedDate = DateTime.Now;
                var dao = new UserDao();
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("cập nhật user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Thêm user thành công", "alert-danger");
                    ModelState.AddModelError("", "cập nhật không user thành công");
                }
            }
            return View(user);

        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}