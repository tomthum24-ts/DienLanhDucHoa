using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategorySlideDao
    {
        ShopDbContext db = null;
        public CategorySlideDao()
        {
            db = new ShopDbContext();
        }
        public long Insert(CategorySlide entity)
        {
            db.CategorySlides.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(CategorySlide entity)
        {
            try
            {
                var cate = db.CategorySlides.Find(entity.Id);
                cate.TenLoaiSlide = entity.TenLoaiSlide;
                cate.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public CategorySlide GetbyID(long id)
        {
            return db.CategorySlides.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var cate = db.Categories.Find(id);
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }

            catch (Exception)
            {

                return false;
            }

        }
        public IEnumerable<CategorySlide> ListAllPaging(int page, int pageSize)
        {
            return db.CategorySlides.ToPagedList(page, pageSize);
        }
        public List<CategorySlide> ListAll()
        {
            return db.CategorySlides.Where(x => x.Status == true).ToList();
        }
        public bool? ChangeStatus(long id)
        {
            var cate = db.Categories.Find(id);
            cate.Status = !cate.Status;
            db.SaveChanges();
            return cate.Status;
        }
        public CategorySlide ViewDetail(long id)
        {
            return db.CategorySlides.Find(id);
        }
        public List<CategorySlide> ListCat(int top)
        {
            return db.CategorySlides.Where(x => x.Status == true).Take(top).ToList();
        }
        public string GetName(int id)
        {
            var name = db.CategorySlides.Where(x => x.Id == id).Select(x => x.TenLoaiSlide).FirstOrDefault();
            return name;
        }
    }
}
