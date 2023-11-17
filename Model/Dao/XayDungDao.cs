
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Dao
{
    public class XayDungDao
    {
        ShopDbContext db = null;
        public XayDungDao()
        {
            db = new ShopDbContext();
        }
        public XayDung GetbyID(long id)
        {
            var data= db.XayDungs.Find(id);
            if (data?.Status == true)
            {
                return data;
            }
            return new XayDung();
        }
        public long Insert(XayDung entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.XayDungs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(XayDung entity)
        {
            try
            {
                var data = db.XayDungs.Find(entity.Id);
                data.Stt = entity.Stt;
                data.TenDuAn = entity.TenDuAn;
                data.MoTa = entity.MoTa;
                data.ViTri = entity.ViTri;
                data.Description = entity.Description;
                data.MetaTitle = entity.MetaTitle;
                data.Image = entity.Image;
                data.Status = entity.Status;
                data.Title = entity.Title;
                data.LoaiDuAn = entity.LoaiDuAn;
                data.TienIch = entity.TienIch;
                data.TongQuan = entity.TongQuan;
                data.VitriImage = entity.VitriImage;
                data.ModifiedBy = entity.ModifiedBy;
                data.ModifiedDate = DateTime.Now;
                data.TongQuanImage = entity.TongQuanImage;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<XayDung> ListAllPaging(ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.XayDungs.Where(x => x.Status == true).Count();
            return db.XayDungs.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.XayDungs.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.XayDungs.Find(id);
                db.XayDungs.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public IEnumerable<XayDung> ListCategoryDuAn( int id,ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.XayDungs.Where(x => x.Status == true && x.Id== id).Count();
            return db.XayDungs.Where(x => x.Status == true && x.Id == id).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        ///Danh sách tài trang người dùng
        public List<XayDung> ListAll()
        {
            return db.XayDungs.Where(x => x.Status == true).OrderByDescending(x => x.Stt).ToList();
        }
        public List<XayDung> ListAllAdm()
        {
            return db.XayDungs.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<XayDung> ListNewHome()
        {
            return db.XayDungs.Where(x => x.Status == true).Take(5).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public XayDung ViewDetail(long id)
        {
            return db.XayDungs.Find(id);
        }
        //public List<XayDung> ListSuggest(long noGet)
        //{
        //    return db.XayDungs.Where(x => x.Status == true && x.ID != noGet).Take((int)EnumSuggestNew.New_ChiTiet_suggest).OrderBy(x => x.CreatedDate).ToList();
        //}
        public List<XayDung> Listcate(long id)
        {
            return db.XayDungs.Where(x=>x.Id== id).ToList();
        }
    

    }
}
