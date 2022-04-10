using KARAOKE.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KARAOKE.Models.Dao
{
    public class ThongKeDao
    {
        KaraokeDbContext db = null;
        public ThongKeDao()
        {
            db = new KaraokeDbContext();
        }
        public IEnumerable<HoaDonBanHang> ThongKePhong(DateTime tuNgay, DateTime toiNgay)
        {
            IQueryable<HoaDonBanHang> result = db.HoaDonBanHang;
            result = result.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay);
            //var result = from hd in db.HoaDonBanHang.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)
            //             join p in db.Phong on hd.IDPhong equals p.ID
            //             select new LineHang
            //             {
            //                 NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
            //                 MaHang = Convert.ToString(p.ID),
            //                 Mathang = p.TenPhong,
            //                 DVT = "Giờ",
            //                 DG = (int)hd.DonGiaPhong,
            //                 SL = new LinePhong(((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalHours).ToString(),
            //                 ThanhTien = (int)new LinePhong().ThanhTien(((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalHours, (int)hd.DonGiaPhong)
            //             };
            return result.ToList();
        }


        public List<LineHang> ThongKeHang(DateTime tuNgay, DateTime toiNgay)
        {
            var result = from hd in db.HoaDonBanHang.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)
                         join ct in db.ChiTietHoaDonBanHang on hd.IDHoaDon equals ct.IDHoaDon
                         join h in db.MatHang.Where(x => x.isDichVu == false) on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinh on h.IDDVT equals dv.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(h.ID),
                             Mathang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = Convert.ToString(ct.SL),
                             DG = (int)ct.DonGia,
                             ThanhTien = (int)(ct.SL * ct.DonGia)
                         };
            return result.ToList();
        }
        public List<LineHang> ThongKeDichVu(DateTime tuNgay, DateTime toiNgay)
        {
            var result = from hd in db.HoaDonBanHang.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)
                         join ct in db.ChiTietHoaDonBanHang on hd.IDHoaDon equals ct.IDHoaDon
                         join h in db.MatHang.Where(x => x.isDichVu == true) on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinh on h.IDDVT equals dv.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(h.ID),
                             Mathang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = Convert.ToString(ct.SL),
                             DG = (int)ct.DonGia,
                             ThanhTien = (int)(ct.SL * ct.DonGia)
                         };
            return result.ToList();
        }
    }
}