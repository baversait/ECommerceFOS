using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
