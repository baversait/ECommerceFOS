using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class AddressDTO
    {
        public int AddressID { get; set; }
        public string AddressStr { get; set; }
        public string AddressTitle { get; set; }
        public int? TownID { get; set; }
        public int? CityID { get; set; }
        public int? CountryID { get; set; }
        public string TownName { get; set; }
        public int? PostalCode { get; set; }

        public virtual TownDTO Town { get; set; }
    }
}