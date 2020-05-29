namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDSuaChua")]
    public partial class HDSuaChua
    {
        [Key]
        [StringLength(50)]
        public string MaHDSC { get; set; }

        [StringLength(50)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string MaVatTu { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public double? ThanhTien { get; set; }
    }
}
