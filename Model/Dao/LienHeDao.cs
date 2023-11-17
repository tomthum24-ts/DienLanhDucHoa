using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LienHeDao
    {
        ShopDbContext db = null;
        public LienHeDao()
        {
            db = new ShopDbContext();
        }
        public IEnumerable<LienHe> ListAll()
        {
            return db.LienHes.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public IEnumerable<LienHe> ListAllPagingAd(int page, int pageSize)
        {
            return db.LienHes.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public long Insert(LienHe entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.Status = true;
            entity.ModifiedDate = DateTime.Now;
            db.LienHes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(LienHe entity)
        {
            try
            {
                var LienHe = db.LienHes.Find(entity.Id);
                entity.ModifiedBy = entity.ModifiedBy;
                entity.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public LienHe GetbyID(long id)
        {
            return db.LienHes.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var LienHe = db.LienHes.Find(id);
            LienHe.Status = !LienHe.Status;
            db.SaveChanges();
            return LienHe.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var LienHe = db.LienHes.Find(id);
                db.LienHes.Remove(LienHe);
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
