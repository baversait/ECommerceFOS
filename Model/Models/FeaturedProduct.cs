using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class FeaturedProduct
    {
        public int FeaturedProductID { get; set; }
        public int ProductID { get; set; }
        public int? Priority { get; set; }
        public bool IsShown { get; set; }

        public virtual ProductDetail ProductDetail { get; set; }
    }
}
