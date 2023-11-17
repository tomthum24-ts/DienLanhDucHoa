using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BoiCanhDao
    {
        ShopDbContext db = null;
        public BoiCanhDao()
        {
            db = new ShopDbContext();
        }
        public BoiCanh GetbyID(long id)
        {
            return db.BoiCanhs.Find(id);
        }
        public long Insert(BoiCanh entity)
        {
            db.BoiCanhs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(BoiCanh entity)
        {
            try
            {
                var content = db.BoiCanhs.Find(entity.ID);
                content.Image = entity.Image;
                content.DisplayOrder = entity.DisplayOrder;
                content.Description = entity.Description;
                content.Image = entity.Image;
                content.NoiDung = entity.NoiDung;
                content.Link = entity.Link;
                content.Description = entity.Description;
                content.CreatedDate = entity.CreatedDate;
                entity.ModifiedBy = entity.ModifiedBy;
                entity.ModifiedDate = DateTime.Now;
                entity.Status = entity.Status;
                entity.Classmain = entity.Classmain;
                entity.IdDuAn = entity.IdDuAn;
                entity.Title = entity.Title;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<BoiCanh> ListAllPaging(int page, int pageSize)
        {
            return db.BoiCanhs.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.BoiCanhs.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.BoiCanhs.Find(id);
                db.BoiCanhs.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool DeleteAll(int id)
        {
            try
            {
                var getAllBoiCanh = db.BoiCanhs.Where(x => x.IdDuAn == id).ToList();
                foreach (var item in getAllBoiCanh)
                {
                    var content = db.BoiCanhs.Find(item.ID);
                    db.BoiCanhs.Remove(content);
                    db.SaveChanges();
                    
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<BoiCanh> ListAll()
        {
            return db.BoiCanhs.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<BoiCanh> ListNewHome()
        {
            return db.BoiCanhs.Where(x => x.Status == true).Take(5).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public BoiCanh ViewDetail(long id)
        {
            return db.BoiCanhs.Find(id);
        }
        //public List<BoiCanh> ListSuggest(long noGet)
        //{
        //    return db.BoiCanhs.Where(x => x.Status == true && x.ID != noGet).Take((int)EnumSuggestNew.New_ChiTiet_suggest).OrderBy(x => x.CreatedDate).ToList();
        //}
        public List<BoiCanh> Listcate(long id)
        {
            return db.BoiCanhs.Where(x => x.Status == true && x.IdDuAn == id).OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}
