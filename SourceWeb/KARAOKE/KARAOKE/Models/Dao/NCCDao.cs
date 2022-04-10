using KARAOKE.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE.Models.Dao
{
    public class NCCDao
    {
        KaraokeDbContext db = null;
        public NCCDao()
        {
            db = new KaraokeDbContext();
        }
        public long Insert(NCC entity)
        {
            db.NCC.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(NCC entity)
        {
            try
            {
                var ncc = db.NCC.Find(entity.ID);
                ncc.TenNCC = entity.TenNCC;
                ncc.Email = entity.Email;
                ncc.DienThoai = entity.DienThoai;
                ncc.DiaChi = entity.DiaChi;
                ncc.NguoiCapNhat = entity.NguoiCapNhat;
                ncc.NgayCapNhat = DateTime.Now;
                ncc.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IEnumerable<NCC> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<NCC> model = db.NCC;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenNCC.Contains(searchString) || x.Email.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public NCC ViewDetail(int id)
        {
            return db.NCC.Find(id);
        }
        public NCC GetById(string Name)
        {
            return db.NCC.SingleOrDefault(x => x.TenNCC == Name);
        }
        public bool Delete(int id)
        {
            try
            {
                var ncc = db.NCC.Find(id);
                db.NCC.Remove(ncc);
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