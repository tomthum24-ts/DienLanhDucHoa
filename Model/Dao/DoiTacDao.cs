using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DoiTacDao
    {
        ShopDbContext db = null;
        public DoiTacDao()
        {
            db = new ShopDbContext();
        }
        public DoiTac GetbyID(long id)
        {
            return db.DoiTacs.Find(id);
        }
        public long Insert(DoiTac entity)
        {
            db.DoiTacs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(DoiTac entity)
        {
            try
            {
                var content = db.DoiTacs.Find(entity.Id);
                content.TenDoiTac = entity.TenDoiTac;
                content.HinhAnh = entity.HinhAnh;
                content.Link = entity.Link;
                content.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<DoiTac> ListAllPagingAdmin(int page, int pageSize)
        {

            return db.DoiTacs.ToPagedList(page, pageSize);
        }
        public IEnumerable<DoiTac> ListAllPaging(ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.DoiTacs.Where(x => x.Status == true).Count();
            return db.DoiTacs.Where(x => x.Status == true).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.DoiTacs.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.DoiTacs.Find(id);
                db.DoiTacs.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<DoiTac> ListAll()
        {
            return db.DoiTacs.Where(x => x.Status == true).ToList();
        }
        public List<DoiTac> ListNewHome()
        {
            return db.DoiTacs.Where(x => x.Status == true).Take(5).ToList();
        }
        public DoiTac ViewDetail(long id)
        {
            return db.DoiTacs.Find(id);
        }

    }
}
