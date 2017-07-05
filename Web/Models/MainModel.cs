using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.DTOs;

namespace Web.Models
{
    public class MainModel: IMainModel
    {
        public List<CurrencyDTO> Currencies { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public List<BrandDTO> Brands { get; set; }
        public CompanyInfoDTO CompanyInfo { get; set; }

        public void FillDatas(MainModel data)
        {
            this.Currencies = data.Currencies;
            this.Categories = data.Categories;
            this.Brands = data.Brands;
            this.CompanyInfo = data.CompanyInfo;
        }
    }

    public interface IMainModel
    {
        void FillDatas(MainModel data);
    }
}