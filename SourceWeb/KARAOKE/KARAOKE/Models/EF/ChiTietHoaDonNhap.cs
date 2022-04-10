namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDonNhap")]
    public partial class ChiTietHoaDonNhap
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IDHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMatHang { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGiaNhap { get; set; }

        public virtual HoaDonNhap HoaDonNhap { get; set; }

        public virtual MatHang MatHang { get; set; }
    }
}
