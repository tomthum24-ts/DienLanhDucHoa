using Model.EF;
using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enum;

namespace Model.Dao
{
    public class PhucLoiDao
    {
        ShopDbContext db = null;
        public PhucLoiDao()
        {
            db = new ShopDbContext();
        }
        public List<PhucLoi> ListByGroup(int idCategory)
        {
            var mainPhucLoi = db.PhucLois.Where(x => x.Status == true).ToList();
            return mainPhucLoi;
        }
        public List<PhucLoi> ListAll()
        {
            return db.PhucLois.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<PhucLoi> ListAllPagingAd()
        {

            return db.PhucLois.OrderByDescending(x=>x.CreatedDate).ToList();
        }

        public long Insert(PhucLoi entity)
        {

            db.PhucLois.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(PhucLoi entity)
        {
            try
            {
                var phucLoi = db.PhucLois.Find(entity.Id);
                phucLoi.Name = entity.Name;
                phucLoi.Image = entity.Image;
                phucLoi.Status = entity.Status;
                phucLoi.NoiDung = entity.NoiDung;
                phucLoi.CreatedDate = DateTime.Now;
                phucLoi.IsPhucLoi = entity.IsPhucLoi;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public PhucLoi GetbyID(long id)
        {
            return db.PhucLois.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var PhucLoi = db.PhucLois.Find(id);
            PhucLoi.Status = !PhucLoi.Status;
            db.SaveChanges();
            return PhucLoi.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var PhucLoi = db.PhucLois.Find(id);
                db.PhucLois.Remove(PhucLoi);
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
