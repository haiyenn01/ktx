using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlurasightLogin.Models
{
    [Table("BaiViet")]
    public class BaiViet
    {
        public int Id { get; set; }
        public string TieuDe { get; set; }
        public string Anh { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayTao { get; set; }
    }
}