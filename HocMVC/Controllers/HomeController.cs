using HocMVC.App_Start;
using HocMVC.Common;
using HocMVC.Models;
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
    public class HomeController : Controller
    {
        // GET: Home
        [Compress]
        public ActionResult Index()
        {
            var quangcao = new QuangCaoDao().ListAll();
            ViewBag.QuangCao = quangcao;
            var footer = new FooterDao().GetFooter();
            ViewBag.Footer= footer;
            var socical = new HotLineDao().ListAll().Where(x => x.IsChat == false);
            ViewBag.Social = socical;
            return View();
        }

        //[ChildActionOnly]
        //[OutputCache(Duration = 3600 * 24)]
        public ActionResult MainMenu()
        {
            var footer = new FooterDao().GetFooter();
            ViewBag.Footer = footer;
            var linhvuc = new LinhVucHoatDongDao().ListAll();
            ViewBag.LinhVucHoatDong = linhvuc;
            var loaitin = new CategoryDao().ListAll();
            ViewBag.LoaiTin = loaitin;
            var loaiBDS = new LoaiDuAnDao().ListAll();
            ViewBag.LoaiBDS = loaiBDS;
            var xayDung = new LoaiXayDungDao().ListAll();
            ViewBag.XayDung = xayDung;
            var amThuc = new AmThucDao().ListAll();
            ViewBag.AmThuc = amThuc;
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult PageLoading()
        {
            
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult CategoryMain()
        {
            var model = new MenuDao().ListByCate();
            return PartialView(model.ToList());
        }
        [ChildActionOnly]
        public ActionResult MainmenuMobile()
        {
            var model = new MenuDao().ListByGroup(1);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Slide()
        {
            var model = new SlideDao().ListByGroup((int)EnumManHinh.TrangChu);
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult LinhVucHoatDong()
        {
           
            var model = new LinhVucHoatDongDao().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Project()
        {
            int totalRecord = 0;
            var model = new DuAnDao().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult News()
        {

            var model = new ContentDao().ListNewHome();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Partner()
        {
            var model = new DoiTacDao().ListAll();
            return PartialView(model);
        }
        // [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new LienHe();
            var footer = new FooterDao().GetFooter();
            var socical = new HotLineDao().ListAll().Where(x => x.IsChat == false);
            ViewBag.Footer = footer;
            ViewBag.Social = socical;
            return PartialView(model);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {

            var cart = Session[SessionKT.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                ViewBag.Total = total;
            }
            return PartialView(list);
        }
        public PartialViewResult Menubottom()
        {

            var cart = Session[SessionKT.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                ViewBag.Total = total;
            }
            return PartialView(list);
        }
        public ActionResult Script_Header()
        {
            var model = new MenuDao().ListAll();
            return PartialView(model);
        }
        [ChildActionOnly]
        public ActionResult Hotline()
        {
            var item = new HotLineDao().ListAll().Where(x=>x.IsChat==true);
            return PartialView(item);
        }
        public PartialViewResult AddItem()
        {

            var cart = Session[SessionKT.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            decimal total = 0;
            foreach (var item in list)
            {
                total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                ViewBag.Total = total;
            }
            return PartialView(list);
        }
        [HttpPost]
        public ActionResult AddLienHe(LienHe param)
        {

            if (ModelState.IsValid)
            {
                var daoLienHe = new LienHeDao();
                daoLienHe.Insert(param);
            }
            return View();
        }
    }
}