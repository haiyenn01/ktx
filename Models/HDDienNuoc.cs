namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDDienNuoc")]
    public partial class HDDienNuoc
    {
        [Key]
        [StringLength(50)]
        public string MaHDDN { get; set; }

        [StringLength(50)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string MaPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        [StringLength(50)]
        public string MaDien { get; set; }

        public double? SoDien { get; set; }

        [StringLength(50)]
        public string MaNuoc { get; set; }

        public double? SoNuoc { get; set; }

        public double? TongTien { get; set; }
    }
}
