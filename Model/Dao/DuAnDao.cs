using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DuAnDao
    {
        ShopDbContext db = null;
        public DuAnDao()
        {
            db = new ShopDbContext();
        }
        //Tìm kiếm sản phẩm
        public IEnumerable<string> ListName(string keyword)
        {
            return db.DuAns.Where(x => x.TenDuAn.Contains(keyword)).Select(x => x.TenDuAn).ToList();
        }
        public IEnumerable<DuAn> GetListSearch(string keyword)
        {
            return db.DuAns.Where(x => x.TenDuAn.Contains(keyword)).ToList();
        }
        public IEnumerable<DuAn> ListAllPaging(ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.DuAns.Where(x => x.Status == true).Count();
            return db.DuAns.Where(x => x.Status == true).OrderByDescending(x=>x.CreatedDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<DuAn> ListAll()
        {
            return db.DuAns.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public IEnumerable<DuAn> ListAllAdmin()
        {
            return db.DuAns.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public IEnumerable<DuAn> ListAllPagingAd(int page, int pageSize)
        {
            return db.DuAns.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<DuAn> ListCategoryDuAn(int id, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.DuAns.Where(x => x.Status == true && x.LoaiDuAn == id).Count();
            return db.DuAns.Where(x => x.Status == true && x.LoaiDuAn == id).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public long Insert(DuAn entity)
        {

            db.DuAns.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(DuAn entity)
        {
            try
            {
                var duAn = db.DuAns.Find(entity.Id);
                duAn.Stt=entity.Stt;
                duAn.TenDuAn = entity.TenDuAn;
                duAn.MoTa = entity.MoTa;
                duAn.ViTri = entity.ViTri;
                duAn.Description = entity.Description;
                duAn.MetaTitle = entity.MetaTitle;
                duAn.Image = entity.Image;
                duAn.Status = entity.Status;
                duAn.Title = entity.Title;
                duAn.LoaiDuAn = entity.LoaiDuAn;
                duAn.TienIch = entity.TienIch;
                duAn.TongQuan = entity.TongQuan;
                duAn.VitriImage = entity.VitriImage;
                duAn.ModifiedBy = entity.ModifiedBy;
                duAn.ModifiedDate = DateTime.Now;
                duAn.TongQuanImage = entity.TongQuanImage;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public DuAn ViewDetail(long id)
        {
            var data = db.DuAns?.Find(id);
            if (data.Status == true)
            {
                return data;
            }
            return new DuAn();
        }
        public bool ChangeStatus(long id)
        {
            var DuAn = db.DuAns.Find(id);
            DuAn.Status = !DuAn.Status;
            db.SaveChanges();
            return DuAn.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var DuAn = db.DuAns.Find(id);
                db.DuAns.Remove(DuAn);
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
