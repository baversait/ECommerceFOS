using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Color
    {
        public int ColorID { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
