using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models.DTOs
{
    public class UserDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Phone { get; set; }
        public string Role { get; set; } = "customer";
        public string ImagePath { get; set; }

        public virtual AddressDTO Address { get; set; }

    }
}