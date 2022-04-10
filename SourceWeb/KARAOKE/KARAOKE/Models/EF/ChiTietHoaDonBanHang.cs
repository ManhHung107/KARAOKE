namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDonBanHang")]
    public partial class ChiTietHoaDonBanHang
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long IDHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDMatHang { get; set; }

        public int? SL { get; set; }

        [StringLength(50)]
        public string NguoiBan { get; set; }

        public int? DonGia { get; set; }

        public virtual HoaDonBanHang HoaDonBanHang { get; set; }

        public virtual MatHang MatHang { get; set; }
    }
}
