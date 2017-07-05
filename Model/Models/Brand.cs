using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Info { get; set; }
        public string Website { get; set; }
        public int? AddressID { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
