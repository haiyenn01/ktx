namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class Phong
    {
        [Key]
        [StringLength(50)]
        public string MaPhong { get; set; }

        [StringLength(50)]
        public string TenPhong { get; set; }

        [StringLength(50)]
        public string MaKhu { get; set; }

        public double? GiaPhong { get; set; }

        public int? SoGiuong { get; set; }
    }
}
