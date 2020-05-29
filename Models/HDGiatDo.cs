namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDGiatDo")]
    public partial class HDGiatDo
    {
        [Key]
        [StringLength(50)]
        public string MaHDGiatDo { get; set; }

        [StringLength(50)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string MaLoai { get; set; }

        public int? SL { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        public double? TongTien { get; set; }
    }
}
