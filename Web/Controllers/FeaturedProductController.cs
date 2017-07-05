using AutoMapper;
using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class FeaturedProductController : Controller, IService<FeaturedProductDTO>
    {
        IFeaturedProductsRepository featuredProductsRepository;
        public FeaturedProductController(IFeaturedProductsRepository featuredProductsRepository)
        {
            this.featuredProductsRepository = featuredProductsRepository;
        }

        // GET: FeaturedProduct
        public ActionResult Index()
        {
            var featuredProducts = featuredProductsRepository.GetAll().ToList();
            var featuredProductsDto = Mapper.Map<List<FeaturedProduct>, List<FeaturedProductDTO>>(featuredProducts);
            

            return Json(featuredProductsDto, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(FeaturedProductDTO entity)
        {
            FeaturedProduct f = Mapper.Map<FeaturedProductDTO, FeaturedProduct>(entity);
            featuredProductsRepository.Add(f);
            featuredProductsRepository.Save();

            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(FeaturedProductDTO entity)
        {
            try
            {
                FeaturedProduct f = featuredProductsRepository.GetById(entity.FeaturedProductID);
                featuredProductsRepository.Delete(f);
                featuredProductsRepository.Save();
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        public ActionResult Edit(FeaturedProductDTO entity)
        {
            FeaturedProduct f = Mapper.Map<FeaturedProductDTO, FeaturedProduct>(entity);
            featuredProductsRepository.Update(f);
            featuredProductsRepository.Save();
            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByID(int id)
        {
            try
            {
                FeaturedProduct f = featuredProductsRepository.GetById(id);                
                return Json(f, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            
        }

        
    }
}