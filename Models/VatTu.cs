namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VatTu")]
    public partial class VatTu
    {
        [Key]
        [StringLength(50)]
        public string MaVatTu { get; set; }

        [StringLength(50)]
        public string Loai { get; set; }

        public int? SoLuong { get; set; }

        public double? Gia { get; set; }
    }
}
