using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string OrderDateStr { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string ShippedDateStr { get; set; }
        public int ShippingTypeID { get; set; }
        public int? AddressID { get; set; }
        public string Notes { get; set; }

        public virtual UserDTO Customer { get; set; }
        public virtual AddressDTO Address { get; set; }
        public virtual ShippingTypesDTO ShippingType { get; set; }

        public virtual ICollection<OrderDetailDTO> OrderDetails { get; set; }
    }
}