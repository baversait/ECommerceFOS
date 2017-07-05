using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class FrontPageBanner
    {
        public int FrontPageBannerID { get; set; }
        public string ForwardAddress { get; set; }
        public bool IsShown { get; set; }
        public bool IsCarousel { get; set; }
        public bool IsSampleBanner { get; set; }
        public bool IsBlockBanner { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
