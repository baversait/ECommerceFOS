using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class TownDTO
    {
        public int TownID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }

        public virtual CityDTO City { get; set; }= new CityDTO();
    }
}