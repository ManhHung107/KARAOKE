namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatHang")]
    public partial class MatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MatHang()
        {
            ChiTietHoaDonBanHang = new HashSet<ChiTietHoaDonBanHang>();
            ChiTietHoaDonNhap = new HashSet<ChiTietHoaDonNhap>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenMatHang { get; set; }

        public int? IDDVT { get; set; }

        public int DonGiaBan { get; set; }

        public int? IdCha { get; set; }

        public int? Tile { get; set; }

        public bool? isDichVu { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiCapNhat { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public bool? Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonBanHang> ChiTietHoaDonBanHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }
        public List<DonViTinh> listDVT = new List<DonViTinh>();
        public virtual DonViTinh DonViTinh { get; set; }
    }
}
