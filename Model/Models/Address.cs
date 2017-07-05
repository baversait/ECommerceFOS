using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressStr { get; set; }
        public string AddressTitle { get; set; }
        public int? TownID { get; set; }
        public int? PostalCode { get; set; }

        public virtual Town Town { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<CompanyInfo> CompanyInfos { get; set; }
        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
