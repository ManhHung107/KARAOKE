using KARAOKE.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE.Models.Dao
{
    public class LoaiPhongDao
    {
        KaraokeDbContext db = null;
        public LoaiPhongDao()
        {
            db = new KaraokeDbContext();
        }
        public long Insert(LoaiPhong entity)
        {
            db.LoaiPhong.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(LoaiPhong entity)
        {
            try
            {
                var lp = db.LoaiPhong.Find(entity.ID);
                lp.TenLoaiPhong = entity.TenLoaiPhong;
                lp.DonGia = entity.DonGia;
                lp.NguoiCapNhat = entity.NguoiCapNhat;
                lp.NgayCapNhat = DateTime.Now;
                lp.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IEnumerable<LoaiPhong> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<LoaiPhong> model = db.LoaiPhong;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenLoaiPhong.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public LoaiPhong ViewDetail(int id)
        {
            return db.LoaiPhong.Find(id);
        }
        public LoaiPhong GetById(string Name)
        {
            return db.LoaiPhong.SingleOrDefault(x => x.TenLoaiPhong == Name);
        }
        public bool Delete(int id)
        {
            try
            {
                var lp = db.LoaiPhong.Find(id);
                db.LoaiPhong.Remove(lp);
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