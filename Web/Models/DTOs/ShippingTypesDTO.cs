using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class ShippingTypesDTO
    {
        public int ShippingTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerItem { get; set; }
    }
}