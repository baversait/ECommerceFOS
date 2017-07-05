using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories;
using Web.Models;
using Web.Models.DTOs;
using AutoMapper;

namespace Web.Controllers
{
    public class FrontPageBannerPageController : BaseController
    {

        //protected IHomeModel homeModel;
        //private HomeModelFiller homeModelFiller;
        //public FrontPageBannerPageController(IHomeModel homeModel, IFrontPageBannerRepository frontPageRepository):base(new HomeModel(IHomeModel))
        //{
        //    this.frontPageRepository = frontPageRepository;

        //    this.homeModelFiller = new HomeModelFiller(frontPageRepository);

        //    homeModel.FillDatas(homeModelFiller.GetHomeModel());
        //    this.homeModel = homeModel;
        //}
        private IFrontPageBannerRepository frontPageBannerRepository;

        public FrontPageBannerPageController(
            ICurrencyRepository currencyRepository, 
            ICompanyInfoRepository companyInfoRepository, 
            ICategoryRepository categoryRepository, 
            IBrandRepository brandRepository, 
            IFrontPageBannerRepository frontPageBannerRepository) : base(new FrontPageBannerModel(), 
                currencyRepository, 
                companyInfoRepository, 
                categoryRepository, 
                brandRepository)
        {
            this.frontPageBannerRepository = frontPageBannerRepository;
        }

        // GET: FrontPageBannerPage
        public ActionResult Index()
        {
            var f = frontPageBannerRepository.GetAll().ToList();
            List<FrontPageBannerDTO> frontPageBanner = Mapper.Map<List<FrontPageBannerDTO>>(f);
            
            
            FrontPageBannerModel model = (FrontPageBannerModel)mainModel;
            model.FrontPageBanner = frontPageBanner;
            

            return View(model);
        }
    }
}