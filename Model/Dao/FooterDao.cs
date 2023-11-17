using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FooterDao
    {
        ShopDbContext db = null;
        public FooterDao()
        {
            db = new ShopDbContext();
        }

  
        public bool Update(Footer entity)
        {
            try
            {
                var Footer = db.Footers.Find(entity.ID);
                Footer.Logo = entity.Logo;
                Footer.Name = entity.Name;
                Footer.Hotline = entity.Hotline;
                Footer.Website = entity.Website;
                Footer.Image = entity.Image;
                Footer.DiaChi = entity.DiaChi;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Footer ViewDetail(long id)
        {
            return db.Footers.Find(id);
        }
        public Footer GetFooter()
        {
            return  db.Footers?.FirstOrDefault();
        }

    }
}
