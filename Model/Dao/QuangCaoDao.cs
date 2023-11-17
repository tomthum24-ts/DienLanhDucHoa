using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class QuangCaoDao
    {
        ShopDbContext db = null;
        public QuangCaoDao()
        {
            db = new ShopDbContext();
        }
        public QuangCao GetbyID(long id)
        {
            return db.QuangCaos.Find(id);
        }
        public long Insert(QuangCao entity)
        {
            db.QuangCaos.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(QuangCao entity)
        {
            try
            {
                var QuangCao = db.QuangCaos.Find(entity.Id);
                QuangCao.Name = entity.Name;
                QuangCao.Image = entity.Image;
                QuangCao.Status = entity.Status;
                QuangCao.Link = entity.Link;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<QuangCao> ListAllPaging(int page, int pageSize)
        {
            return db.QuangCaos.ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var QuangCao = db.QuangCaos.Find(id);
            QuangCao.Status = !QuangCao.Status;
            db.SaveChanges();
            return QuangCao.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var QuangCao = db.QuangCaos.Find(id);
                db.QuangCaos.Remove(QuangCao);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<QuangCao> ListAll()
        {
            return db.QuangCaos.Where(x => x.Status == true).ToList();
        }
        public List<QuangCao> ListAllAdmin()
        {
            return db.QuangCaos.ToList();
        }
        public QuangCao ViewDetail(long id)
        {
            return db.QuangCaos.Find(id);
        }

        public List<QuangCao> Listcate(long id)
        {
            return db.QuangCaos.Where(x => x.Status == true).ToList();
        }
    }
}
