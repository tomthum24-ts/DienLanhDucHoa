using Model.Dao;
using Model.EF;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var project = new DuAnDao().ListAllPaging(ref totalRecord, page, pageSize);
            ViewBag.LoaiDuAn= new LoaiDuAnDao().ListAll();
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.DuAn);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.Title = project?.FirstOrDefault().TenDuAn;
            ViewBag.Description = project?.FirstOrDefault().Description;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage + 1;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage + 1;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(project);
        }
        public ActionResult Category(int id=0, int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var category = new DuAnDao().ListCategoryDuAn(id, ref totalRecord, page, pageSize);
            ViewBag.LoaiDuAn = new LoaiDuAnDao().ListAll();
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.DuAn);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            var loaiDuAn = new LoaiDuAnDao().ListCategory(id);
            ViewBag.Title = loaiDuAn?.FirstOrDefault()?.TenLoaiDuAn ;
            ViewBag.Description = loaiDuAn?.FirstOrDefault()?.MetaDescriptions ;
            ViewBag.Id = id;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage + 1;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage + 1;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(category);
        }

        public ActionResult Detail(long id)
        {
            ViewBag.LoaiDuAn = new LoaiDuAnDao().ListAll();
            var model = new DuAnDao().ViewDetail(id);
            var boiCanh= new BoiCanhDao().Listcate(id);

            if (model == null)
            {
                var item = new DuAn();
                return View(item);
            }
            if(boiCanh == null || boiCanh.Count ==0)
            {
                var item = new List<BoiCanh>();
                ViewBag.BoiCanh = item;
            }
            else
            {
                ViewBag.BoiCanh = boiCanh;
            }
            ViewBag.Title = model?.TenDuAn;
            ViewBag.Description = model?.Description;
            ViewBag.Keywords = model?.MoTa;
            return View(model);
        }
        public JsonResult ListName(string q)
        {
            var data = new DuAnDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true

            }, JsonRequestBehavior.AllowGet
                );
        }
        public ActionResult TimKiem(string keysearch)
        {

            var data = new DuAnDao().GetListSearch(keysearch);
            ViewBag.CountItem = data.Count();
            ViewBag.keySearch = keysearch;
            return View(data);
        }

    }
}