using Model.Dao;
using Model.EF;
using Model.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HocMVC.Controllers
{
    public class TuyenDungController : Controller
    {
        // GET: TuyenDung
        public ActionResult Index()
        {
            ViewBag.GetListTuyenDung = new ViTriTuyenDungDao().ListAll();
            ViewBag.Slide = new SlideDao().ListByGroup((int)EnumManHinh.TuyenDung);
            ViewBag.NoiDung = new PhucLoiDao().ListAll().Where(x => x.IsPhucLoi == false);
            ViewBag.PhucLoi = new PhucLoiDao().ListAll().Where(x => x.IsPhucLoi == true);
            return View();
        }
        [HttpPost]
        public ActionResult AddHoSo(TuyenDung param, HttpPostedFileBase myFiles )
        {
            var duongDan = "~/Public/Images/files/";
            if (ModelState.IsValid)
            {
                var daoTuyenDung = new TuyenDungDao();
                param.CreatedDate = DateTime.Now;
                param.ModifiedDate = DateTime.Now;
                if (myFiles != null)
                {
                    var fileName = Path.GetFileName(myFiles.FileName);
                    var path = Path.Combine(Server.MapPath(duongDan), fileName);
                    myFiles.SaveAs(path);
                    param.CV =  fileName;
                }
                daoTuyenDung.Insert(param);
            }
            return View();
        }
    }
}