namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiPhong")]
    public partial class LoaiPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhong()
        {
            Phong = new HashSet<Phong>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoaiPhong { get; set; }

        public int? DonGia { get; set; }

        public bool? Status { get; set; }

        public DateTime? NgayTao { get; set; }

        [StringLength(30)]
        public string NguoiTao { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        [StringLength(30)]
        public string NguoiCapNhat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phong> Phong { get; set; }
    }
}
