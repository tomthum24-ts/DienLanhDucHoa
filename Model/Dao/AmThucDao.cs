using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class AmThucDao
    {
        ShopDbContext db = null;
        public AmThucDao()
        {
            db = new ShopDbContext();
        }
        public AmThuc GetbyID(long id)
        {
            return db.AmThucs.Find(id);
        }
        public long Insert(AmThuc entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.AmThucs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(AmThuc entity)
        {
            try
            {
                var content = db.AmThucs.Find(entity.Id);
                content.Stt = entity.Stt;
                content.TenDuAn = entity.TenDuAn;
                content.MoTa = entity.MoTa;
                content.Link = entity.Link;
                content.ViTri = entity.ViTri;
                content.TongQuan = entity.TongQuan;
                content.Description = entity.Description;
                content.MetaTitle = entity.MetaTitle;
                content.Image = entity.Image;
                content.CreatedDate = DateTime.Now;
                content.Status = entity.Status;
                content.Title = entity.Title;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<AmThuc> ListAllPaging(int page, int pageSize)
        {
            return db.AmThucs.OrderByDescending(x => x.Stt).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.AmThucs.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.AmThucs.Find(id);
                db.AmThucs.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<AmThuc> ListAll()
        {
            return db.AmThucs.Where(x => x.Status == true).OrderByDescending(x => x.Stt).ToList();
        }
        public List<AmThuc> ListAllAdm()
        {
            return db.AmThucs.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public List<AmThuc> ListNewHome()
        {
            return db.AmThucs.Where(x => x.Status == true).Take(5).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public AmThuc ViewDetail(long id)
        {
            return db.AmThucs.Find(id);
        }
        //public List<AmThuc> ListSuggest(long noGet)
        //{
        //    return db.AmThucs.Where(x => x.Status == true && x.ID != noGet).Take((int)EnumSuggestNew.New_ChiTiet_suggest).OrderBy(x => x.CreatedDate).ToList();
        //}
        public List<AmThuc> Listcate(long id)
        {
            return db.AmThucs.OrderByDescending(x => x.CreatedDate).ToList();
        }


    }
}
