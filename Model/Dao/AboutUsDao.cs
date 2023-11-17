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
    public class AboutUsDao
    {
        ShopDbContext db = null;
        public AboutUsDao()
        {
            db = new ShopDbContext();
        }
        public List<AboutUs> ListByGroup(int idCategory)
        {
            var mainAboutUs = db.AboutUss.Where(x => x.Status == true).ToList();
            return mainAboutUs;
        }
        public List<AboutUs> ListAll()
        {
            return db.AboutUss.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<AboutUs> ListAllPagingAd(int page, int pageSize)
        {

            return db.AboutUss.ToPagedList(page, pageSize);
        }

        public long Insert(AboutUs entity)
        {

            db.AboutUss.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(AboutUs entity)
        {
            try
            {
                var AboutUs = db.AboutUss.Find(entity.ID);
                AboutUs.Name = entity.Name;
                AboutUs.Image = entity.Image;
                AboutUs.Status = entity.Status;
                AboutUs.GhiChu = entity.GhiChu;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public AboutUs GetbyID(long id)
        {
            return db.AboutUss.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var AboutUs = db.AboutUss.Find(id);
            AboutUs.Status = !AboutUs.Status ;
            db.SaveChanges();
            return AboutUs.Status ;
        }
        public bool Delete(int id)
        {
            try
            {
                var AboutUs = db.AboutUss.Find(id);
                db.AboutUss.Remove(AboutUs);
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
