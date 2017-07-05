using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.Models;

namespace Web.Models.DTOs
{
    public class CompanyInfoDTO
    {
        public int CompanyInfoID { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public int? AddressID { get; set; }
        public string AboutUs { get; set; }
        public int CountryID { get; set; }
        public int CityID { get; set; }
        public int TownID { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<ImageDTO> LogoImages { get; set; }
        public virtual AddressDTO Address { get; set; }
    }
}