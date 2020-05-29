namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDThuePhong")]
    public partial class HDThuePhong
    {
        [Key]
        [StringLength(50)]
        public string MaHDP { get; set; }

        [StringLength(50)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string TenSV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThue { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        [StringLength(50)]
        public string MaPhong { get; set; }

        public double? Gia { get; set; }
    }
}
