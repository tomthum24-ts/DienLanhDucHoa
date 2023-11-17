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
    public class XayDungController : Controller
    {
        // GET: XayDung
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var project = new XayDungDao().ListAllPaging(ref totalRecord, page, pageSize);
            ViewBag.LoaiDuAn = new LoaiXayDungDao().ListAll();
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.XayDung);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

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
        public ActionResult Category(int id, int page = 1, int pageSize = 10)
        {
            int totalRecord = 0;
            var category = new XayDungDao().ListCategoryDuAn(id, ref totalRecord, page, pageSize);
            ViewBag.LoaiDuAn = new LoaiXayDungDao().ListAll();
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.XayDung);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            
            ViewBag.Title = category?.FirstOrDefault()?.TenDuAn ;
            ViewBag.Description = category?.FirstOrDefault()?.Description ;
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

        public ActionResult Detail(long id = 0)
        {
            ViewBag.LoaiDuAn = new LoaiXayDungDao().ListAll();
            var model = new XayDungDao().ViewDetail(id);
            var boiCanh = new BoiCanhDao().Listcate(id);

            if (model == null)
            {
                var item = new XayDung();
                return View(item);
            }
            if (boiCanh == null || boiCanh.Count == 0)
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
    }
}