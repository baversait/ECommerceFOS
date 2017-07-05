using Web.Models.DTOs;

namespace Web.Models
{
    public class ProductDetailModel:MainModel
    {
        public ProductDetailDTO ProductDetail { get; set; }
        public ProductDTO Product { get; set; }
    }
}