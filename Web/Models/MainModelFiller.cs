using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Data.Repositories;
using Web.Models.DTOs;

namespace Web.Models
{
    public class MainModelFiller
    {
        private ICurrencyRepository currencyRepository;
        private ICompanyInfoRepository companyInfoRepository;
        private ICategoryRepository categoryRepository;
        private IBrandRepository brandRepository;

        public MainModelFiller(
            ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository
            )
        {
            this.currencyRepository = currencyRepository;
            this.companyInfoRepository = companyInfoRepository;
            this.categoryRepository = categoryRepository;
            this.brandRepository = brandRepository;
        }

        public MainModel GetMainModel()
        {
            MainModel mainModel = new MainModel();
            mainModel.Currencies = GetCurrencyDtos();
            mainModel.CompanyInfo = GetCompanyInfoDto();
            mainModel.Categories = GetCategoryDtos();
            mainModel.Brands = GetBrandDtos();
            return mainModel;
        }

        public List<CurrencyDTO> GetCurrencyDtos()
        {
            var currencies = currencyRepository.GetAll().ToList();
            return Mapper.Map<List<CurrencyDTO>>(currencies);
        }

        public CompanyInfoDTO GetCompanyInfoDto()
        {
            var companyInfo = companyInfoRepository.GetAll().FirstOrDefault();
            return Mapper.Map<CompanyInfoDTO>(companyInfo);
        }

        public List<CategoryDTO> GetCategoryDtos()
        {
            var categories = categoryRepository.GetAll().ToList();
            return Mapper.Map<List<CategoryDTO>>(categories);
        }

        public List<BrandDTO> GetBrandDtos()
        {
            var brands = brandRepository.GetAll().ToList();
            return Mapper.Map<List<BrandDTO>>(brands);
        }

    }

}