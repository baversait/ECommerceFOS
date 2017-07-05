using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Data.Repositories;
using Model.Models;
using Web.Models;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class ProductPageController : BaseController
    {
        private IProductDetailRepository productDetailRepository;

        public ProductPageController(
            ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IProductDetailRepository productDetailRepository) : base(new ProductDetailModel(),
                currencyRepository,
                companyInfoRepository,
                categoryRepository,
                brandRepository)
        {
            this.productDetailRepository = productDetailRepository;
        }

        // GET: ProductPage
        public ActionResult Product(int? id)
        {
            int productDetailID = 0;
            if (id != null)
            {
                productDetailID = (int)id;
            }
            ProductDetail p = productDetailRepository.GetById(productDetailID) ?? productDetailRepository.GetAll().FirstOrDefault();

            var model = (ProductDetailModel)mainModel;
            model.ProductDetail = Mapper.Map<ProductDetailDTO>(p);
            if (model.ProductDetail.Discount != null)
            {
                
                model.ProductDetail.CurrentUnitPrice = model.ProductDetail.UnitPrice *
                                                       (100 - (decimal) model.ProductDetail.Discount) / 100;
            }
            else
            {
                model.ProductDetail.CurrentUnitPrice = model.ProductDetail.UnitPrice;
            }
            model.Product = Mapper.Map<ProductDTO>(p.Product);
            return View(model);
        }
    }
}