using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Town
    {
        public int TownID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Address> Addresses{ get; set; }
    }
}
