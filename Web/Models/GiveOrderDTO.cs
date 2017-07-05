using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models
{
    public class GiveOrderDTO
    {
        public AddressDTO ShippingAddress { get; set; }
        public string Notes { get; set; }
        public int CartID { get; set; }
        public int ShippingTypeID { get; set; }
    }
}