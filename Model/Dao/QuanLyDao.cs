using Model.EF;
using Model.Enum;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class QuanLyDao
    {
        ShopDbContext db = null;
        public QuanLyDao()
        {
            db = new ShopDbContext();
        }
        public IEnumerable<QuanLy> ListAll()
        {
            return db.QuanLys.Where(x => x.Status == true).OrderByDescending(x => x.STT).ToList();
        }
        public IEnumerable<QuanLy> ListAllAdmin()
        {
            return db.QuanLys.OrderBy(x => x.IdPhanLoai ).OrderBy(y =>y.STT).ToList();
        }
        public List<QuanLyViewModel> ListAdmin()
        {
            var list = new List<QuanLyViewModel>();
            var data= db.QuanLys.OrderBy(x => x.IdPhanLoai).OrderBy(y => y.STT).ToList();
            foreach (var item in data)
            {
                var newItem = new QuanLyViewModel();
                newItem.ID=item.ID;
                newItem.Name=item.Name;
                newItem.STT=item.STT;
                newItem.IdPhanLoai = item.IdPhanLoai;
                newItem.TenChucVu = item.TenChucVu;
                newItem.GioiTinh = item.GioiTinh;
                newItem.LoiNgo = item.LoiNgo;
                newItem.ChiTiet = item.ChiTiet;
                newItem.Avata = item.Avata;
                newItem.Status = item.Status;
                newItem.IdCongTy = item.IdCongTy;
                newItem.TenCongTy = GetNameCompany(item.IdCongTy ?? 0);
                list.Add(newItem);
            }
            return list.OrderBy(x => x.IdPhanLoai).OrderBy(y => y.STT).ToList();
        }
        public string GetNameCompany(int idCongty)
        {
            var nameCompany = db.CongTyQuanLys.Where(x => x.Id == idCongty).FirstOrDefault();
            return nameCompany.TenCongTy;
        }
        public IEnumerable<QuanLy> ListAllPagingAd(int page, int pageSize)
        {
            return db.QuanLys.OrderByDescending(x => x.STT).ToPagedList(page, pageSize);
        }
        public List<QuanLy> ListCategoryQuanLy(int id)
        {

            return db.QuanLys.Where(x => x.Status == true && x.IdPhanLoai == id).OrderBy(x => x.STT).ToList();
        }
        public List<QuanLy> ListCategoryQuanLyCongTy(int idPhanLoai)
        {

           var data=  db.QuanLys.Where(x => x.Status == true && x.IdPhanLoai==idPhanLoai).OrderBy(x => x.STT).ToList();
            return data;
        }
        public long Insert(QuanLy entity)
        {

            db.QuanLys.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(QuanLy entity)
        {
            try
            {
                var quanLy = db.QuanLys.Find(entity.ID);
                quanLy.Name = entity.Name;
                quanLy.IdPhanLoai = entity.IdPhanLoai;
                quanLy.TenChucVu = entity.TenChucVu;
                quanLy.GioiTinh = entity.GioiTinh;
                quanLy.LoiNgo = entity.LoiNgo;
                quanLy.ChiTiet = entity.ChiTiet;
                quanLy.Avata = entity.Avata;
                quanLy.Status = entity.Status;
                quanLy.IdCongTy = entity.IdCongTy;
                quanLy.STT = entity.STT;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public QuanLy ViewDetail(long id)
        {
            return db.QuanLys.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var quanLy = db.QuanLys.Find(id);
            quanLy.Status = !quanLy.Status;
            db.SaveChanges();
            return quanLy.Status ;
        }
        public bool Delete(int id)
        {
            try
            {
                var quanLy = db.QuanLys.Find(id);
                db.QuanLys.Remove(quanLy);
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
