using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ScritpHeaderDao
    {
        ShopDbContext db = null;
        public ScritpHeaderDao()
        {
            db = new ShopDbContext();
        }
        public List<ScritpHeader> ListByGroup(int IdManHinh)
        {
            var mainScritpHeader = db.ScritpHeaders.Where(x => x.Status == true).ToList();
            return mainScritpHeader;
        }
        public List<ScritpHeader> ListAll()
        {
            return db.ScritpHeaders.Where(x => x.Status == true).ToList();
        }

        public async Task<IEnumerable<ScritpHeader>> ListAllPagingAd()
        {
            return await db.ScritpHeaders.ToListAsync();
        }
        public long Insert(ScritpHeader entity)
        {

            db.ScritpHeaders.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(ScritpHeader entity)
        {
            try
            {
                var data = db.ScritpHeaders.Find(entity.ID);
                data.Name = entity.Name;
                data.Code = entity.Code;
                data.Note = entity.Note;
                data.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public ScritpHeader GetbyID(long id)
        {
            return db.ScritpHeaders.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var data = db.ScritpHeaders.Find(id);
            data.Status = !data.Status;
            db.SaveChanges();
            return data.Status ;
        }
        public bool Delete(int id)
        {
            try
            {
                var data = db.ScritpHeaders.Find(id);
                db.ScritpHeaders.Remove(data);
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
