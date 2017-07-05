using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class BrandDTO
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string Info { get; set; }
        public string Website { get; set; }
        public string ImagePath { get; set; }
        public int? AddressID { get; set; }

        public virtual AddressDTO Address { get; set; }
        public virtual ICollection<ImageDTO> Images { get; set; }
    }
}