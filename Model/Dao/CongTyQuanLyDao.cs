using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CongTyQuanLyDao
    {

        ShopDbContext db = null;
        public CongTyQuanLyDao()
        {
            db = new ShopDbContext();
        }
        public IEnumerable<CongTyQuanLy> ListAll()
        {
            return db.CongTyQuanLys.Where(x => x.Status == true).OrderByDescending(x => x.STT).ToList();
        }
        public IEnumerable<CongTyQuanLy> ListAllAdmin()
        {
            return db.CongTyQuanLys.OrderByDescending(x => x.STT).ToList();
        }
        public IEnumerable<CongTyQuanLy> ListAllPagingAd(int page, int pageSize)
        {
            return db.CongTyQuanLys.OrderByDescending(x => x.STT).ToPagedList(page, pageSize);
        }
        public List<CongTyQuanLy> ListCategoryCongTyQuanLy(int id)
        {

            return db.CongTyQuanLys.Where(x => x.Status == true && x.Id == id).OrderByDescending(x => x.STT).ToList();
        }
        public long Insert(CongTyQuanLy entity)
        {

            db.CongTyQuanLys.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(CongTyQuanLy entity)
        {
            try
            {
                var congTyQuanLy = db.CongTyQuanLys.Find(entity.Id);
                congTyQuanLy.TenCongTy = entity.TenCongTy;
                congTyQuanLy.STT = entity.STT;
                congTyQuanLy.GhiChu = entity.GhiChu;
                congTyQuanLy.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public CongTyQuanLy ViewDetail(long id)
        {
            return db.CongTyQuanLys.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var CongTyQuanLy = db.CongTyQuanLys.Find(id);
            CongTyQuanLy.Status = !CongTyQuanLy.Status;
            db.SaveChanges();
            return CongTyQuanLy.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var CongTyQuanLy = db.CongTyQuanLys.Find(id);
                db.CongTyQuanLys.Remove(CongTyQuanLy);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
