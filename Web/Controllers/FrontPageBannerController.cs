using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.DTOs;
using AutoMapper;

namespace Web.Controllers
{
    public class FrontPageBannerController : Controller, IService<FrontPageBannerDTO>
    {
        private IFrontPageBannerRepository frontPageRepository;
        public FrontPageBannerController(IFrontPageBannerRepository frontPageRepository)
        {
            this.frontPageRepository = frontPageRepository;
        }

        // GET: FrontPageBanner
        public ActionResult Index()
        {
            //try
            //{
            //    List<FrontPageBannerDTO> frontPageBanners = frontPageRepository.GetAll().Select(x => new FrontPageBannerDTO
            //    {
            //        FrontPageBannerID = x.FrontPageBannerID,
            //        ForwardAddress = x.ForwardAddress,
            //        IsBlockBanner = x.IsBlockBanner,
            //        IsCarousel = x.IsCarousel,
            //        IsSampleBanner = x.IsSampleBanner,
            //        IsShown = x.IsShown

            //    }).ToList();
            //    return Json(frontPageBanners, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception e)
            //{

            //    return Json(false, JsonRequestBehavior.DenyGet);
            //}

            var frontPage = frontPageRepository.GetAll().ToList();
            var frontPageDTO = Mapper.Map<List<FrontPageBanner>, List<FrontPageBannerDTO>>(frontPage);
            return Json(frontPageDTO, JsonRequestBehavior.AllowGet);
            

        }
        [HttpPost]
        public ActionResult Add(FrontPageBannerDTO entity)
        {
                FrontPageBanner frontPage = Mapper.Map<FrontPageBannerDTO, FrontPageBanner>(entity);
                frontPageRepository.Add(frontPage);
                frontPageRepository.Save();
                return Json(entity, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public ActionResult Delete(FrontPageBannerDTO entity)
        {
            try
            {
                FrontPageBanner f = frontPageRepository.GetById(entity.FrontPageBannerID);

                frontPageRepository.Delete(f);
                frontPageRepository.Save();

                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult Edit(FrontPageBannerDTO entity)
        {
            FrontPageBanner frontPage = Mapper.Map<FrontPageBannerDTO, FrontPageBanner>(entity);
            frontPageRepository.Update(frontPage);
            frontPageRepository.Save();
            return Json(entity, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetByID(int id)
        {
            try
            {
                FrontPageBanner f = frontPageRepository.GetById(id);
                FrontPageBannerDTO frontPageDto = new FrontPageBannerDTO
                {
                    FrontPageBannerID = f.FrontPageBannerID,
                    ForwardAddress = f.ForwardAddress,
                    IsBlockBanner = f.IsBlockBanner,
                    IsCarousel = f.IsCarousel,
                    IsSampleBanner = f.IsSampleBanner,
                    IsShown = f.IsShown
                };

                return Json(frontPageDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
            
        }

        
    }
}