using KARAOKE.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE.Models.Dao
{
    public class ProductDao
    {
        KaraokeDbContext db = null;
        public ProductDao()
        {
            db = new KaraokeDbContext();
        }
        public long Insert(MatHang entity)
        {
            db.MatHang.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(MatHang entity)
        {
            try
            {
                var product = db.MatHang.Find(entity.ID);
                product.TenMatHang = entity.TenMatHang;
                product.DonViTinh = entity.DonViTinh;
                product.DonGiaBan = entity.DonGiaBan;
                product.IdCha = entity.IdCha;
                product.Tile = entity.Tile;
                product.NguoiCapNhat = entity.NguoiCapNhat;
                product.NgayCapNhat = DateTime.Now;
                product.isDichVu = entity.isDichVu;
                product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IEnumerable<MatHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<MatHang> model = db.MatHang;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenMatHang.Contains(searchString));
            }
            //return View(data.Products.Where(x => x.CategoryID == 1).ToList().OrderBy(n => n.ID).ToPagedList(pageNumber, pageSize));
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public MatHang ViewDetail(int id)
        {
            return db.MatHang.Find(id);
        }
        public MatHang GetById(string name)
        {
            return db.MatHang.SingleOrDefault(x => x.TenMatHang == name);
        }
        public bool Delete(int id)
        {
            try
            {
                var product = db.MatHang.Find(id);
                db.MatHang.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public MatHang GetDVT()
        {
            MatHang objCourse = new MatHang();
            objCourse.listDVT = db.DonViTinh.ToList();
            return objCourse;
        }

    }

}