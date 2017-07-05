using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models.DTOs
{
    public class FrontPageBannerDTO
    {
        public int FrontPageBannerID { get; set; }
        public string ForwardAddress { get; set; }
        public bool IsShown { get; set; }
        public bool IsCarousel { get; set; }
        public bool IsSampleBanner { get; set; }
        public bool IsBlockBanner { get; set; }
        

        public virtual ICollection<ImageDTO> Images { get; set; }
    }
}