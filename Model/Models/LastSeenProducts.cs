using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class LastSeenProducts
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime SeenAt { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
