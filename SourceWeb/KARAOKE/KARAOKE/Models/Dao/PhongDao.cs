using KARAOKE.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE.Models.Dao
{
    public class PhongDao
    {
        KaraokeDbContext db = null;
        public PhongDao()
        {
            db = new KaraokeDbContext();
        }
        public long Insert(Phong entity)
        {
            db.Phong.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Phong entity)
        {
            try
            {
                var p = db.Phong.Find(entity.ID);
                p.TenPhong = entity.TenPhong;
                p.IDLoaiPhong = entity.IDLoaiPhong;
                p.SucChua = entity.SucChua;
                p.NguoiCapNhat = entity.NguoiCapNhat;
                p.NgayCapNhat = DateTime.Now;
                p.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IEnumerable<Phong> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Phong> model = db.Phong;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenPhong.Contains(searchString) || x.LoaiPhong.TenLoaiPhong.Contains(searchString));
            }
            return model.OrderByDescending(x => x.LoaiPhong.TenLoaiPhong).ToPagedList(page, pageSize);
        }
        public Phong ViewDetail(int id)
        {
            return db.Phong.Find(id);
        }
        public Phong GetById(string Name)
        {
            return db.Phong.SingleOrDefault(x => x.TenPhong == Name);
        }
        public bool Delete(int id)
        {
            try
            {
                var p = db.Phong.Find(id);
                db.Phong.Remove(p);
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