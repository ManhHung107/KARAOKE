namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDonBanHang = new HashSet<HoaDonBanHang>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string HoVaTen { get; set; }

        [StringLength(30)]
        public string DienThoai { get; set; }

        [StringLength(150)]
        public string DiaChi { get; set; }

        public bool isAdmin { get; set; }

        public bool? Status { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(30)]
        public string NguoiCapNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHang { get; set; }
    }
}
