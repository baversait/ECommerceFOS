using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Models;

namespace Web.Models.DTOs
{
    public class CountryDTO
    {
        public int CountryID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CityDTO> Cities { get; set; }
    }
}