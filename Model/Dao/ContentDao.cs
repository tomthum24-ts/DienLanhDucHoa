﻿using Model.EF;
using Model.Enum;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContentDao
    {
        ShopDbContext db = null;
        public ContentDao()
        {
            db = new ShopDbContext();
        }
        public Contents GetbyID(long id)
        {
            return db.Contents.Find(id);
        }
        public long Insert(Contents entity)
        {
            db.Contents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Contents entity)
        {
            try
            {
                var content = db.Contents.Find(entity.ID);
                content.Name = entity.Name;
                content.MetaTitle = entity.MetaTitle;
                content.Description = entity.Description;
                content.Image = entity.Image;
                content.CategoryID = entity.CategoryID;
                content.Detail = entity.Detail;
                content.MetaKeywords = entity.MetaKeywords;
                content.MetaDescriptions = entity.MetaDescriptions;
                entity.ModifiedBy = entity.ModifiedBy;
                entity.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public IEnumerable<Contents> ListAllPagingAdmin( int page, int pageSize)
        {
       
            return db.Contents.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<Contents> ListAllPaging(ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.Contents.Where(x => x.Status==true).Count();
            return db.Contents.Where(x => x.Status == true).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var content = db.Contents.Find(id);
            content.Status = !content.Status;
            db.SaveChanges();
            return content.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.Contents.Find(id);
                db.Contents.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        ///Danh sách tài trang người dùng
        public List<Contents> ListAll()
        {
            return db.Contents.Where(x => x.Status == true).OrderByDescending(x=>x.CreatedDate).ToList();
        }
        public List<Contents> ListNewHome()
        {
            return db.Contents.Where(x => x.Status == true).Take(5).OrderByDescending(x => x.CreatedDate).ToList();
        }
        public Contents ViewDetail(long id)
        {
            return db.Contents.Find(id);
        }
        public List<Contents> ListSuggest( long noGet)
        {
            return db.Contents.Where(x => x.Status == true && x.ID != noGet).OrderByDescending(x => x.CreatedDate).Take((int)EnumSuggestNew.New_ChiTiet_suggest).ToList();
        }
        public IEnumerable<Contents> Listcate(long id, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.Contents.Where(x => x.Status == true && x.CategoryID == id).Count();
            return db.Contents.Where(x => x.Status == true && x.CategoryID==id).OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
    }
    
}
