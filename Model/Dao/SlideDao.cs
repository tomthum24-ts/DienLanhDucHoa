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
    public  class SlideDao
    {
        ShopDbContext db = null;
        public SlideDao()
        {
            db = new ShopDbContext();
        }
        public List<Slide> ListByGroup(int idCategory)
        {
            var mainSlide= db.Slides.Where(x => x.Status == true &&x.IDCategory== idCategory).OrderByDescending(x=>x.DisplayOrder).ToList();
            return mainSlide;
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public IEnumerable<Slide> ListAllPagingAd(int page, int pageSize)
        {
            var slide = db.Slides.ToList();
            foreach (var item in slide)
            {
                item.TenManHinh = new CategorySlideDao().GetName(item.IDCategory ?? 0);
            }
            return slide.ToPagedList(page, pageSize);
        }
     
        public long Insert(Slide entity)
        {

            db.Slides.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Slide entity)
        {
            try
            {
                var slide = db.Slides.Find(entity.ID);
                slide.Image = entity.Image;
                slide.DisplayOrder = entity.DisplayOrder;
                slide.NoiDung = entity.NoiDung;
                slide.Link = entity.Link;
                slide.Description = entity.Description;
                slide.CreatedDate = DateTime.Now;
                slide.CreatedBy = "Admin";
                slide.Status = entity.Status;
                slide.Classmain = entity.Classmain;
                slide.IDCategory = entity.IDCategory;
                entity.ModifiedBy = entity.ModifiedBy;
                entity.ModifiedDate = DateTime.Now;
                slide.NoiDung = entity.NoiDung;
                slide.Title = entity.Title;
                slide.IdManHinh = entity.IdManHinh;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Slide GetbyID(long id)
        {
            return db.Slides.Find(id);
        }
        public bool ChangeStatus(long id)
        {
            var slide = db.Slides.Find(id);
            slide.Status = !slide.Status;
            db.SaveChanges();
            return slide.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var slide = db.Slides.Find(id);
                db.Slides.Remove(slide);
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
