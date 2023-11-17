using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class TuyenDungDao
    {
        ShopDbContext db = null;
        public TuyenDungDao()
        {
            db = new ShopDbContext();
        }
        public TuyenDung GetbyID(long id)
        {
            return db.TuyenDungs.Find(id);
        }
        public long Insert(TuyenDung entity)
        {
            db.TuyenDungs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(TuyenDung entity)
        {
            try
            {
                var content = db.TuyenDungs.Find(entity.Id);
                content.Name = entity.Name;
                content.PhoneNumber = entity.PhoneNumber;
                content.Email = entity.Email;
                content.ViTri = entity.ViTri;
                content.GhiChu = entity.GhiChu;
                content.CV = entity.CV;
                content.CreatedDate = entity.CreatedDate;
                entity.ModifiedBy = entity.ModifiedBy;
                entity.ModifiedDate = DateTime.Now;
                entity.Status = entity.Status;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<TuyenDung> ListAllPaging(int page, int pageSize)
        {
            return db.TuyenDungs.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.TuyenDungs.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.TuyenDungs.Find(id);
                db.TuyenDungs.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<TuyenDung> ListAll()
        {
            return db.TuyenDungs.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<TuyenDung> ListAllAdm()
        {
            return db.TuyenDungs.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<TuyenDung> ListNewHome()
        {
            return db.TuyenDungs.Where(x => x.Status == true).Take(5).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public TuyenDung ViewDetail(long id)
        {
            return db.TuyenDungs.Find(id);
        }
        //public List<TuyenDung> ListSuggest(long noGet)
        //{
        //    return db.TuyenDungs.Where(x => x.Status == true && x.ID != noGet).Take((int)EnumSuggestNew.New_ChiTiet_suggest).OrderBy(x => x.CreatedDate).ToList();
        //}
        public List<TuyenDung> Listcate(long id)
        {
            return db.TuyenDungs.OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
