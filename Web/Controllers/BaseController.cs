using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories;
using Web.Models;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        private ICurrencyRepository currencyRepository;
        private ICompanyInfoRepository companyInfoRepository;
        private ICategoryRepository categoryRepository;
        private IBrandRepository brandRepository;

        

        protected IMainModel mainModel;
        private MainModelFiller mainModelFiller;

        public BaseController(
            IMainModel mainModel,
            ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository
            )
        {
            this.currencyRepository = currencyRepository;
            this.companyInfoRepository = companyInfoRepository;
            this.categoryRepository = categoryRepository;

            this.mainModelFiller = new MainModelFiller(currencyRepository,
                companyInfoRepository,
                categoryRepository,
                brandRepository);

            mainModel.FillDatas(mainModelFiller.GetMainModel());
            this.mainModel = mainModel;
        }
}
}