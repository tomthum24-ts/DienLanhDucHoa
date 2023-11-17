using Model.Dao;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            var quanLy = new QuanLyDao().ListAll();
            ViewBag.ChuTich = new QuanLyDao().ListCategoryQuanLy((int)EnumQuanLy.ChuTich);
            ViewBag.GiamDocKhoi = new QuanLyDao().ListCategoryQuanLy((int)EnumQuanLy.GiamDocKhoi);

            ViewBag.BanDieuHanhLand = new QuanLyDao().ListCategoryQuanLyCongTy((int)EnumQuanLy.BanDieuHanh).Where(x => x.IdCongTy == (int)EnumCongTy.Land);
            ViewBag.BanDieuHanhFood = new QuanLyDao().ListCategoryQuanLyCongTy((int)EnumQuanLy.BanDieuHanh).Where(x => x.IdCongTy == (int)EnumCongTy.Food);
            ViewBag.BanDieuHanhConstruct = new QuanLyDao().ListCategoryQuanLyCongTy((int)EnumQuanLy.BanDieuHanh).Where(x => x.IdCongTy == (int)EnumCongTy.Construct);

            ViewBag.ThanhVienLand = new QuanLyDao().ListCategoryQuanLyCongTy((int)EnumQuanLy.ThanhVien).Where(x=>x.IdCongTy== (int)EnumCongTy.Land);
            ViewBag.ThanhVienFood = new QuanLyDao().ListCategoryQuanLyCongTy((int)EnumQuanLy.ThanhVien).Where(x => x.IdCongTy == (int)EnumCongTy.Food);
            ViewBag.ThanhVienConstruct = new QuanLyDao().ListCategoryQuanLyCongTy((int)EnumQuanLy.ThanhVien).Where(x => x.IdCongTy == (int)EnumCongTy.Construct);
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.HoiDongQuanTri);
            return View(quanLy);
        }
    }
}