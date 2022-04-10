using KARAOKE.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE.Models.Dao
{
    public class UserDao
    {
        KaraokeDbContext db = null;
        public UserDao()
        {
            db = new KaraokeDbContext();
        }
        public long Insert(NhanVien entity)
        {
            db.NhanVien.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(NhanVien entity)
        {
            try
            {
                var user = db.NhanVien.Find(entity.ID);
                user.Username = entity.Username;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.HoVaTen = entity.HoVaTen;
                user.DienThoai = entity.DienThoai;
                user.DiaChi = entity.DiaChi;
                user.NguoiCapNhap = entity.NguoiCapNhap;
                user.NgayCapNhat = DateTime.Now;
                user.isAdmin = entity.isAdmin;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
            
        }

        public IEnumerable<NhanVien> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<NhanVien> model = db.NhanVien;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.HoVaTen.Contains(searchString));
            }    
            return model.OrderByDescending(x => x.ID).ToPagedList(page,pageSize);
        }
        public NhanVien ViewDetail(int id)
        {
            return db.NhanVien.Find(id);
        }
        public NhanVien GetById (string UserName)
        {
            return db.NhanVien.SingleOrDefault(x=>x.Username==UserName);
        }
        public bool Login (string userName, string passWord)
        {
            var result = db.NhanVien.Count(x => x.Username == userName && x.Password == passWord);
            if(result>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.NhanVien.Find(id);
                db.NhanVien.Remove(user);
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