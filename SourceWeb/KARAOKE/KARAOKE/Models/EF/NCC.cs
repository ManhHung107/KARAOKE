namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NCC")]
    public partial class NCC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NCC()
        {
            HoaDonNhap = new HashSet<HoaDonNhap>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(150)]
        public string TenNCC { get; set; }

        [StringLength(50)]
        public string DienThoai { get; set; }

        [StringLength(150)]
        public string DiaChi { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public bool? Status { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(30)]
        public string NguoiCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }
    }
}
