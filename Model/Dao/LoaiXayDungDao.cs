using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class LoaiXayDungDao
    {
        ShopDbContext db = null;
        public LoaiXayDungDao()
        {
            db = new ShopDbContext();
        }
        public List<LoaiXayDung> ListByGroup(int IdManHinh)
        {
            var mainLoaiXayDung = db.LoaiXayDungs.Where(x => x.Status == true ).OrderBy(x => x.Stt).ToList();
            return mainLoaiXayDung;
        }
        public List<LoaiXayDung> ListAll()
        {
            return db.LoaiXayDungs.Where(x => x.Status == true).OrderBy(x => x.Stt).ToList();
        }
        public List<LoaiXayDung> ListCategory(int id)
        {
            return db.LoaiXayDungs.Where(x => x.Status == true && x.Id== id).ToList();
        }
        public async Task<IEnumerable<LoaiXayDung>> ListAllPagingAd()
        {
            return await db.LoaiXayDungs.OrderBy(x => x.Stt).ToListAsync();
        }
        public long Insert(LoaiXayDung entity)
        {

            db.LoaiXayDungs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(LoaiXayDung entity)
        {
            try
            {
                var loaiXayDung = db.LoaiXayDungs.Find(entity.Id);
                loaiXayDung.TenLoaiDuAn = entity.TenLoaiDuAn;
                loaiXayDung.Status = entity.Status;
                loaiXayDung.SeoTitle = entity.SeoTitle;
                loaiXayDung.MetaKeywords = entity.MetaKeywords;
                loaiXayDung.MetaTitle = entity.MetaTitle;
                loaiXayDung.Stt = entity.Stt;
                loaiXayDung.NoiDung = entity.NoiDung;
                loaiXayDung.Mota = entity.Mota;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public LoaiXayDung GetbyID(long id)
        {
            return db.LoaiXayDungs.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var LoaiXayDung = db.LoaiXayDungs.Find(id);
            LoaiXayDung.Status = !LoaiXayDung.Status;
            db.SaveChanges();
            return LoaiXayDung.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var LoaiXayDung = db.LoaiXayDungs.Find(id);
                db.LoaiXayDungs.Remove(LoaiXayDung);
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
