using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Infrastructure;
using Data.Repositories;
using Model.Models;
using Web.Models;
using Web.Models.DTOs;
using AutoMapper;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private ICurrencyRepository currencyRepository;
        private IFrontPageBannerRepository frontPageBannerRepository;
        //private IImageRepository imageRepository;
        private IFeaturedProductsRepository featuredProductsRepository;
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;

        public HomeController(ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IFrontPageBannerRepository frontPageBannerRepository,
            //IImageRepository imageRepository,
            IFeaturedProductsRepository featuredProductsRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository) : base(
                new HomeModel(),
                currencyRepository,
                companyInfoRepository,
                categoryRepository,
                brandRepository)
        {
            this.currencyRepository = currencyRepository;
            this.frontPageBannerRepository = frontPageBannerRepository;
            //this.imageRepository = imageRepository;
            this.featuredProductsRepository = featuredProductsRepository;
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
        }

        // GET: Home
        public ActionResult Index()
        {
            HomeModel model = (HomeModel)mainModel;

            var frontPageBanners = frontPageBannerRepository.GetAll().Where(x => x.IsCarousel == true && x.IsShown == true).ToList();
            List<FrontPageBannerDTO> frontPageBanner = Mapper.Map<List<FrontPageBannerDTO>>(frontPageBanners);
            model.FrontPageBanner = frontPageBanner;


            var latestProducts = productRepository.GetAll().Reverse().Take(10).ToList();
            List<ProductDTO> latestProductsDTOs = Mapper.Map<List<ProductDTO>>(latestProducts);
            model.LatestProducts = latestProductsDTOs;


            var featuredProducts = featuredProductsRepository.GetAll().Where(x => x.IsShown == true).Take(10);
            List<FeaturedProductDTO> featuredProductDTOs = Mapper.Map<List<FeaturedProductDTO>>(featuredProducts);
            model.FeaturedProduct = featuredProductDTOs;


            var bestSellerProducts = orderRepository.GetBestSellers();
            List<ProductDetailDTO> bestSellerProductDTOs = Mapper.Map<List<ProductDetailDTO>>(bestSellerProducts);
            model.BestSellers = bestSellerProductDTOs;



            return View(model);
        }

        public ActionResult SelectCurrency(int id)
        {
            Currency currency = currencyRepository.GetById(id);
            Session["selectedCurrencyID"] = currency.CurrencyID;
            Session["selectedCurrencyName"] = currency.CurrencyName;
            Session["selectedCurrencySymbol"] = currency.CurrencySymbol;
            return Redirect("/");
        }
    }
}