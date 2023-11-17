using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ViTriTuyenDungDao
    {
        ShopDbContext db = null;
        public ViTriTuyenDungDao()
        {
            db = new ShopDbContext();
        }
        public ViTriTuyenDung GetbyID(long id)
        {
            return db.ViTriTuyenDungs.Find(id);
        }
        public long Insert(ViTriTuyenDung entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.ViTriTuyenDungs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(ViTriTuyenDung entity)
        {
            try
            {
                var content = db.ViTriTuyenDungs.Find(entity.Id);
                content.TenViTri = entity.TenViTri;
                content.SoLuong = entity.SoLuong;
                content.DiaDiem = entity.DiaDiem;
                content.HanNop = entity.HanNop;
                entity.ModifiedBy = entity.ModifiedBy;
                entity.ModifiedDate = DateTime.Now;
                entity.Status = entity.Status;
                entity.Status = entity.Status;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<ViTriTuyenDung> ListAllPaging(int page, int pageSize)
        {
            return db.ViTriTuyenDungs.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.ViTriTuyenDungs.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.ViTriTuyenDungs.Find(id);
                db.ViTriTuyenDungs.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<ViTriTuyenDung> ListAll()
        {
            return db.ViTriTuyenDungs.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<ViTriTuyenDung> ListAllAdm()
        {
            return db.ViTriTuyenDungs.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<ViTriTuyenDung> ListNewHome()
        {
            return db.ViTriTuyenDungs.Where(x => x.Status == true).Take(5).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public ViTriTuyenDung ViewDetail(long id)
        {
            return db.ViTriTuyenDungs.Find(id);
        }
        //public List<ViTriTuyenDung> ListSuggest(long noGet)
        //{
        //    return db.ViTriTuyenDungs.Where(x => x.Status == true && x.ID != noGet).Take((int)EnumSuggestNew.New_ChiTiet_suggest).OrderBy(x => x.CreatedDate).ToList();
        //}
        public List<ViTriTuyenDung> Listcate(long id)
        {
            return db.ViTriTuyenDungs.OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
