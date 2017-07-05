using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class CityDTO
    {
        public int CityID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        public virtual CountryDTO Country { get; set; } = new CountryDTO();
        public virtual ICollection<TownDTO> Towns { get; set; }
    }
}