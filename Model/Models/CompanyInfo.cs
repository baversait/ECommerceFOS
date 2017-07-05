using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class CompanyInfo
    {
        public int CompanyInfoID { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public int? AddressID { get; set; }
        public string AboutUs { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Image> LogoImages { get; set; }
    }
}
