using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models
{
    public class CheckoutModel : MainModel
    {
        public List<ShippingTypesDTO> ShippingTypes { get; set; }
    }
}