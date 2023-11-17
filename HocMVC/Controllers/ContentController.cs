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
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult Index(int page = 1, int pageSize =10)
        {
            int totalRecord = 0;
            var content = new ContentDao().ListAllPaging(ref totalRecord, page, pageSize);
         
            ViewBag.CateGoRyConTent = new CategoryDao().ListAll();
           
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.TinTuc);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage+1;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage+1;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(content);
        }
        public ActionResult Detail(long id = 0)
        {
            var model = new ContentDao().ViewDetail(id);
            if (model == null)
            {
                var item = new Contents();
                return View(item);
            }
            ViewBag.Title = model?.Name;
            ViewBag.Description = model?.MetaDescriptions;
            ViewBag.Keywords = model?.MetaKeywords;
            ViewBag.SuggestNew = new ContentDao().ListSuggest(id);
            ViewBag.CateGoRyConTent = new CategoryDao().ListAll();
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.TinTuc);
            return View(model);
        }
        public ActionResult Category(long id =0, int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var model = new ContentDao().Listcate(id, ref totalRecord, page,pageSize);
            ViewBag.CateGoRyConTent = new CategoryDao().ListAll();
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            ViewBag.IdCategory= new CategoryDao().GetByIdCategory(id);
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.TinTuc);
            ViewBag.Id = id;

            var categoryList = new CategoryDao().GetCategory(id);
            ViewBag.Title = categoryList?.FirstOrDefault()?.Name;
            ViewBag.Description = categoryList?.FirstOrDefault()?.Name;
            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage + 1;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage+1;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
    }
}