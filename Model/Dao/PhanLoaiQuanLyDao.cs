using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class PhanLoaiQuanLyDao
    {
        ShopDbContext db = null;
        public PhanLoaiQuanLyDao()
        {
            db = new ShopDbContext();
        }
        public IEnumerable<PhanLoaiQuanLy> ListAll()
        {
            return db.PhanLoaiQuanLys.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<PhanLoaiQuanLy> ListAllAdmin()
        {
            return db.PhanLoaiQuanLys.ToList();
        }
        public IEnumerable<PhanLoaiQuanLy> ListAllPagingAd(int page, int pageSize)
        {
            return db.PhanLoaiQuanLys.ToPagedList(page, pageSize);
        }
        public List<PhanLoaiQuanLy> ListCategoryPhanLoaiQuanLy(int id)
        {

            return db.PhanLoaiQuanLys.Where(x => x.Status == true ).ToList();
        }
        public long Insert(PhanLoaiQuanLy entity)
        {

            db.PhanLoaiQuanLys.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(PhanLoaiQuanLy entity)
        {
            try
            {
                var PhanLoaiQuanLy = db.PhanLoaiQuanLys.Find(entity.ID);
                PhanLoaiQuanLy.TenPhanLoai = entity.TenPhanLoai;
                PhanLoaiQuanLy.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public PhanLoaiQuanLy ViewDetail(long id)
        {
            return db.PhanLoaiQuanLys.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var PhanLoaiQuanLy = db.PhanLoaiQuanLys.Find(id);
            PhanLoaiQuanLy.Status = !PhanLoaiQuanLy.Status;
            db.SaveChanges();
            return PhanLoaiQuanLy.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var PhanLoaiQuanLy = db.PhanLoaiQuanLys.Find(id);
                db.PhanLoaiQuanLys.Remove(PhanLoaiQuanLy);
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
