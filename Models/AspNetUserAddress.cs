namespace PlurasightLogin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUserAddress
    {
        public string Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public string Country { get; set; }

        public string AddressLine { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
