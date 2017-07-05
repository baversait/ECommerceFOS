using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Data.Repositories;
using Web.Models;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class CategoryPageController : BaseController
    {
        private ICategoryRepository categoryRepository;
        private ISubCategoryRepository subCategoryRepository;
        // GET: CategoryPage
        public CategoryPageController(
            ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            ISubCategoryRepository subCategoryRepository) : base(new SubCategoryModel(),
                currencyRepository,
                companyInfoRepository,
                categoryRepository,
                brandRepository)
        {
            this.categoryRepository = categoryRepository;
            this.subCategoryRepository = subCategoryRepository;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Category");
        }

        public ActionResult Category(int? id, int orderIndex = -1)
        {
            int catID = 0;
            if (id != null)
            {
                catID = (int)id;
            }
            var cat = categoryRepository.GetById(catID);

            CategoryDTO category;

            if (cat == null)
            {
                cat = categoryRepository.GetAll().FirstOrDefault();
            }
            category = Mapper.Map<CategoryDTO>(cat);
            List<ProductDetailDTO> productDetails = GetProductDetailsFromCategory(category, orderIndex);

            var model = ((CategoryModel)mainModel);
            model.Category = category;
            model.ProductDetails = productDetails;

            return View(model);
        }

        public ActionResult SubCategory(int? id, int orderIndex = -1)
        {
            int SubCatID = 0;
            if (id != null)
            {
                SubCatID = (int)id;
            }
            var subCat = subCategoryRepository.GetById(SubCatID);

            SubCategoryDTO subCategory;

            if (subCat == null)
            {
                subCat = subCategoryRepository.GetAll().FirstOrDefault();
            }
            subCategory = Mapper.Map<SubCategoryDTO>(subCat);
            List<ProductDetailDTO> productDetails = GetProductDetailsFromSubCategory(subCategory, orderIndex);

            var model = ((SubCategoryModel)mainModel);
            model.Category = Mapper.Map<CategoryDTO>(subCat.Category);
            model.SubCategory = subCategory;
            model.ProductDetails = productDetails;


            return View(model);
        }


        private List<ProductDetailDTO> GetProductDetailsFromCategory(CategoryDTO category, int orderIndex)
        {
            var subCats = category.SubCategories;
            var products = subCats.Select(x => x.Products);
            List<ProductDetailDTO> productDetailList = new List<ProductDetailDTO>();
            foreach (var item in products)
            {
                foreach (var product in item)
                {
                    foreach (var productDetail in product.ProductDetails)
                    {
                        productDetailList.Add(productDetail);
                    }
                }
            }

            var productDetailEnumerable = (IEnumerable<ProductDetailDTO>)productDetailList;
            return OrderProductDetails(productDetailEnumerable, orderIndex);
        }

        private List<ProductDetailDTO> OrderProductDetails(IEnumerable<ProductDetailDTO> productDetailEnumerable, int orderIndex)
        {
            List<ProductDetailDTO> productDetails;

            switch (orderIndex)
            {
                case 0:
                    productDetails = productDetailEnumerable.OrderBy(x => x.ProductName).ToList();
                    break;
                case 1:
                    productDetails = productDetailEnumerable.OrderByDescending(x => x.ProductName).ToList();
                    break;
                case 2:
                    productDetails = productDetailEnumerable.OrderBy(x => x.UnitPrice).ToList();
                    break;
                case 3:
                    productDetails = productDetailEnumerable.OrderByDescending(x => x.UnitPrice).ToList();
                    break;
                default:
                    productDetails = productDetailEnumerable.ToList();
                    break;
            }
            return productDetails;
        }

        private List<ProductDetailDTO> GetProductDetailsFromSubCategory(SubCategoryDTO subCategory, int orderIndex)
        {
            var products = subCategory.Products;
            List<ProductDetailDTO> productDetailList = new List<ProductDetailDTO>();
            foreach (var product in products)
            {
                foreach (var productDetail in product.ProductDetails)
                {
                    productDetailList.Add(productDetail);
                }
            }

            var productDetailEnumerable = (IEnumerable<ProductDetailDTO>)productDetailList;


            return OrderProductDetails(productDetailEnumerable, orderIndex);
        }
    }
}