using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.BuilderProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlurasightLogin
{
    public class ExtendedUser:IdentityUser
    {
        public ExtendedUser()
        {
            Addresses = new List<Address>();
        }
        public string FullName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
    public class Address
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; internal set; }
    }
}