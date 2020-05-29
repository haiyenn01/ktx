namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhuNha")]
    public partial class KhuNha
    {
        [Key]
        [StringLength(50)]
        public string MaKhu { get; set; }

        [StringLength(50)]
        public string TenKhu { get; set; }

        public int? SoPhong { get; set; }
    }
}
