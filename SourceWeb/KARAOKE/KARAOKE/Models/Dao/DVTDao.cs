using KARAOKE.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE.Models.Dao
{
    public class DVTDao
    {
        KaraokeDbContext db = null;
        public DVTDao()
        {
            db = new KaraokeDbContext();
        }
        public long Insert(DonViTinh entity)
        {
            db.DonViTinh.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(DonViTinh entity)
        {
            try
            {
                var dvt = db.DonViTinh.Find(entity.ID);
                dvt.TenDVT = entity.TenDVT;
                dvt.NguoiCapNhat = entity.NguoiCapNhat;
                dvt.NgayCapNhat = DateTime.Now;
                dvt.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IEnumerable<DonViTinh> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DonViTinh> model = db.DonViTinh;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenDVT.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public DonViTinh ViewDetail(int id)
        {
            return db.DonViTinh.Find(id);
        }
        public DonViTinh GetById(string Name)
        {
            return db.DonViTinh.SingleOrDefault(x => x.TenDVT == Name);
        }
        public bool Delete(int id)
        {
            try
            {
                var dvt = db.DonViTinh.Find(id);
                db.DonViTinh.Remove(dvt);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}