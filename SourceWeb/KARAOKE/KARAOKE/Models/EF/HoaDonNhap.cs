namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonNhap")]
    public partial class HoaDonNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonNhap()
        {
            ChiTietHoaDonNhap = new HashSet<ChiTietHoaDonNhap>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NhanVienNhap { get; set; }

        public int? IDNhaCC { get; set; }

        public DateTime NgayNhap { get; set; }

        public byte? DaNhap { get; set; }

        public int? TienThanhToan { get; set; }

        public DateTime NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(30)]
        public string NguoiCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhap { get; set; }

        public virtual NCC NCC { get; set; }
    }
}
