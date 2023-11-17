using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AboutDao
    {
        ShopDbContext db = null;
        public AboutDao()
        {
            db = new ShopDbContext();
        }


        public bool Update(About entity)
        {
            try
            {
                var aboutUs = db.Abouts.Find(entity.ID);
                aboutUs.Detail = entity.Detail;
                aboutUs.Description = entity.Description;
                aboutUs.MetaKeywords = entity.MetaKeywords;
                aboutUs.MetaTitle = entity.MetaTitle;
                aboutUs.Image = entity.Image;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public About ViewDetail(long id)
        {
            return db.Abouts.Find(id);
        }
        public About GetAbout()
        {
            return db.Abouts.FirstOrDefault();
        }
    }
}
