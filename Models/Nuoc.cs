namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nuoc")]
    public partial class Nuoc
    {
        [Key]
        [StringLength(50)]
        public string MaNuoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TGBatDau { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TGKetThuc { get; set; }

        public double? Gia { get; set; }
    }
}
