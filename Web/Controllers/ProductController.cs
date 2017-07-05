using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Data.Repositories;
using Model.Models;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class ProductController : Controller,IService<ProductDTO>
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: Product
        public ActionResult Index()
        {
            //List<ProductDTO> products = productRepository.GetAll()
            //    .Select(x => new ProductDTO()
            //    {
            //        ProductID = x.ProductID,
            //        ProductName = x.ProductName,
            //        SubCategoryID = x.SubCategoryID,
            //        SubCategoryName = x.SubCategory.SubCategoryName,
            //        BrandID = x.BrandID,
            //        BrandName = x.Brand.BrandName,
            //        SupplierID = x.SupplierID,
            //        SupplierName = x.Supplier.CompanyName,
            //        TaxRate = x.TaxRate,
            //        Specification = x.Specification,
            //        ProductDetails = Mapper.Map<ICollection<ProductDetail>, ICollection<ProductDetailDTO>>(x.ProductDetails)
            //    })
            //    .ToList();


            var products = productRepository.GetAll().ToList();
            var productsDTO = Mapper.Map<List<Product>, List<ProductDTO >> (products);
            return Json(productsDTO, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(ProductDTO entity)
        {
            try
            {
                Product product = Mapper.Map<ProductDTO, Product>(entity);
                productRepository.Add(product);
                productRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Delete(ProductDTO entity)
        {
            try
            {
                Product product = productRepository.GetById(entity.ProductID);
                productRepository.Delete(product);
                productRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Edit(ProductDTO entity)
        {
            try
            {
                Product product = Mapper.Map<ProductDTO, Product>(entity);
                productRepository.Update(product);
                productRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}