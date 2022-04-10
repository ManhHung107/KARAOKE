namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonBanHang")]
    public partial class HoaDonBanHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonBanHang()
        {
            ChiTietHoaDonBanHang = new HashSet<ChiTietHoaDonBanHang>();
        }

        [Key]
        public long IDHoaDon { get; set; }

        public int IDPhong { get; set; }

        public DateTime? ThoiGianBDau { get; set; }

        public DateTime? ThoiGianKThuc { get; set; }

        public int? DonGiaPhong { get; set; }

        public int? IDNguoiBan { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(30)]
        public string NguoiCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonBanHang> ChiTietHoaDonBanHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
