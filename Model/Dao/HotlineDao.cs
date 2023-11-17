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
    public class HotLineDao
    {
        ShopDbContext db = null;
        public HotLineDao()
        {
            db = new ShopDbContext();
        }
        public List<HotLine> ListByGroup(int idCategory)
        {
            var mainHotLine = db.HotLines.Where(x => x.Status == true).ToList();
            return mainHotLine;
        }
        public List<HotLine> ListAll()
        {
            return db.HotLines.Where(x => x.Status == true).ToList();
        }
        public IEnumerable<HotLine> ListAllPagingAd()
        {

            return db.HotLines.ToList();
        }

        public long Insert(HotLine entity)
        {

            db.HotLines.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(HotLine entity)
        {
            try
            {
                var HotLine = db.HotLines.Find(entity.Id);
                HotLine.Name = entity.Name;
                HotLine.Link = entity.Link;
                HotLine.Status = entity.Status;
                HotLine.GhiChu = entity.GhiChu;
                HotLine.Status = entity.Status;
                HotLine.Image = entity.Image;
                HotLine.IsChat = entity.IsChat;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public HotLine GetbyID(long id)
        {
            return db.HotLines.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var HotLine = db.HotLines.Find(id);
            HotLine.Status = !HotLine.Status;
            db.SaveChanges();
            return HotLine.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var HotLine = db.HotLines.Find(id);
                db.HotLines.Remove(HotLine);
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
