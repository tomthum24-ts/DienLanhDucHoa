using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LoaiDuAnDao
    {
        ShopDbContext db = null;
        public LoaiDuAnDao()
        {
            db = new ShopDbContext();
        }
        public List<LoaiDuAn> ListByGroup(int IdManHinh)
        {
            var mainLoaiDuAn = db.LoaiDuAns.Where(x => x.Status == true ).OrderBy(x => x.Stt).ToList();
            return mainLoaiDuAn;
        }
        public List<LoaiDuAn> ListAll()
        {
            return db.LoaiDuAns.Where(x => x.Status == true).OrderBy(x=>x.Stt).ToList();
        }
        public List<LoaiDuAn> ListCategory( int idCategory)
        {
            return db.LoaiDuAns.Where(x => x.Status == true  && x.Id== idCategory).OrderBy(x => x.Stt).ToList();
        }
        public async Task<IEnumerable<LoaiDuAn>> ListAllPagingAd()
        {
            return await db.LoaiDuAns.OrderBy(x => x.Stt).ToListAsync();
        }
        public long Insert(LoaiDuAn entity)
        {

            db.LoaiDuAns.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(LoaiDuAn entity)
        {
            try
            {
                var loaiDuAn = db.LoaiDuAns.Find(entity.Id);
                loaiDuAn.TenLoaiDuAn = entity.TenLoaiDuAn;
                loaiDuAn.Status = entity.Status;
                loaiDuAn.Stt = entity.Stt;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public LoaiDuAn GetbyID(long id)
        {
            return db.LoaiDuAns.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var LoaiDuAn = db.LoaiDuAns.Find(id);
            LoaiDuAn.Status = !LoaiDuAn.Status;
            db.SaveChanges();
            return LoaiDuAn.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var LoaiDuAn = db.LoaiDuAns.Find(id);
                db.LoaiDuAns.Remove(LoaiDuAn);
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
