using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public int? AddressID { get; set; }
        public long? Phone { get; set; }
        public long? Fax { get; set; }
        public string Website { get; set; }
        public bool IsSupplier { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
