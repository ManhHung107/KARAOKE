namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phong()
        {
            HoaDonBanHang = new HashSet<HoaDonBanHang>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenPhong { get; set; }

        public byte? TrangThai { get; set; }

        public int? IDLoaiPhong { get; set; }

        public int? SucChua { get; set; }

        public bool? Status { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(30)]
        public string NguoiCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHang { get; set; }
        public List<LoaiPhong> listLoaiPhong = new List<LoaiPhong>();

        public virtual LoaiPhong LoaiPhong { get; set; }
    }
}
