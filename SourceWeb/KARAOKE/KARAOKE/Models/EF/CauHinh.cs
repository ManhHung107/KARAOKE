namespace KARAOKE.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHinh")]
    public partial class CauHinh
    {
        [Key]
        [StringLength(50)]
        public string tukhoa { get; set; }

        [StringLength(150)]
        public string giatri { get; set; }
    }
}
