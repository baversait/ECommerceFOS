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
    public class ProductDetailController : Controller, IService<ProductDetailDTO>
    {
        private IProductDetailRepository productDetailRepository;

        public ProductDetailController(IProductDetailRepository productDetailRepository)
        {
            this.productDetailRepository = productDetailRepository;
        }
        
        public ActionResult Index()
        {
            var p = productDetailRepository.GetAll().ToList();
            var productDetail = Mapper.Map<List<ProductDetail>, List<ProductDetailDTO>>(p);
            return Json(productDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(ProductDetailDTO entity)
        {
            try
            {
                ProductDetail productDetail = Mapper.Map<ProductDetailDTO, ProductDetail>(entity);
                productDetailRepository.Add(productDetail);
                productDetailRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false , JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(ProductDetailDTO entity)
        {
            try
            {
                ProductDetail productDetail = productDetailRepository.GetById(entity.ProductDetailID);
                productDetailRepository.Delete(productDetail);
                productDetailRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Edit(ProductDetailDTO entity)
        {
            try
            {
                ProductDetail productDetail = Mapper.Map<ProductDetailDTO, ProductDetail>(entity);
                productDetailRepository.Update(productDetail);
                productDetailRepository.Save();
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