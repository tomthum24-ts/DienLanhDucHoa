using Model.EF;
using Model.Enum;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LinhVucHoatDongDao
    {
        ShopDbContext db = null;
        public LinhVucHoatDongDao()
        {
            db = new ShopDbContext();
        }
        public IEnumerable<LinhVucHoatDong> ListAll()
        {
            return db.LinhVucHoatDongs.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public IEnumerable<LinhVucHoatDong> ListAllPagingAd()
        {
            return db.LinhVucHoatDongs.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public long Insert(LinhVucHoatDong entity)
        {
            db.LinhVucHoatDongs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(LinhVucHoatDong entity)
        {
            try
            {
                var LinhVucHoatDong = db.LinhVucHoatDongs.Find(entity.Id);
                LinhVucHoatDong.ModifiedBy = entity.ModifiedBy;
                LinhVucHoatDong.ModifiedDate = DateTime.Now;
                LinhVucHoatDong.Image= entity.Image;
                LinhVucHoatDong.Name = entity.Name;
                LinhVucHoatDong.Link = entity.Link;
                LinhVucHoatDong.Status = entity.Status;
                LinhVucHoatDong.Description = entity.Description;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public LinhVucHoatDong GetbyID(long id)
        {
            return db.LinhVucHoatDongs.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var LinhVucHoatDong = db.LinhVucHoatDongs.Find(id);
            LinhVucHoatDong.Status = !LinhVucHoatDong.Status;
            db.SaveChanges();
            return LinhVucHoatDong.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var LinhVucHoatDong = db.LinhVucHoatDongs.Find(id);
                db.LinhVucHoatDongs.Remove(LinhVucHoatDong);
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
