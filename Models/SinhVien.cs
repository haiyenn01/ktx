namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [Key]
        [StringLength(50)]
        public string MaSV { get; set; }

        [StringLength(50)]
        public string TenSV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        [StringLength(10)]
        public string CMND { get; set; }

        [StringLength(50)]
        public string NoiCap { get; set; }

        [StringLength(50)]
        public string DanToc { get; set; }

        [StringLength(10)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string MaKhoa { get; set; }

        public int? NamHoc { get; set; }

        [StringLength(250)]
        public string Image { get; set; }
    }
}
