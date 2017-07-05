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
    public class CompanyInfoController : Controller, IService<CompanyInfoDTO>
    {
        private ICompanyInfoRepository companyInfoRepository;
        private IImageRepository imageRepository;
        public CompanyInfoController(ICompanyInfoRepository companyInfoRepository, 
            IImageRepository imageRepository)
        {
            this.companyInfoRepository = companyInfoRepository;
            this.imageRepository = imageRepository;
        }

        // GET: CompanyInfo
        public ActionResult Index()
        {
            List<CompanyInfo> companyInfo = companyInfoRepository.GetAll().ToList();
            var companyInfoDTOs = Mapper.Map<List<CompanyInfo>, List<CompanyInfoDTO>>(companyInfo);
            return Json(companyInfoDTOs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(CompanyInfoDTO entity)
        {
            try
            {
                CompanyInfo companyInfo = new CompanyInfo();
                companyInfo.CompanyName = entity.CompanyName;
                companyInfo.AboutUs = entity.AboutUs;
                companyInfo.Email = entity.Email;
                companyInfo.PhoneNumber = entity.PhoneNumber;
                if (entity.Address != null)
                {
                    companyInfo.Address = new Address
                    {
                        AddressStr = entity.Address.AddressStr,
                        AddressTitle = entity.Address.AddressTitle,
                        TownID = entity.Address.TownID,
                        PostalCode = entity.Address.PostalCode
                    };
                }
                companyInfoRepository.Add(companyInfo);
                companyInfoRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Delete(CompanyInfoDTO entity)
        {
            try
            {
                CompanyInfo t = companyInfoRepository.GetById(entity.CompanyInfoID);
                companyInfoRepository.Delete(t);
                companyInfoRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Edit(CompanyInfoDTO entity)
        {
            try
            {
                CompanyInfo companyInfo = companyInfoRepository.GetById(entity.CompanyInfoID);
                companyInfo.CompanyName = entity.CompanyName;
                companyInfo.PhoneNumber = entity.PhoneNumber;
                companyInfo.Email = entity.Email;
                companyInfo.AboutUs = entity.AboutUs;
                companyInfo.Address.AddressStr = entity.Address.AddressStr;
                companyInfo.Address.AddressTitle = entity.Address.AddressTitle;
                companyInfo.Address.TownID = entity.Address.TownID;
                companyInfo.Address.PostalCode = entity.Address.PostalCode;
                if (companyInfo.LogoImages.Count > 0 && entity.LogoImages != null && entity.LogoImages.Count > 0)
                {
                    companyInfo.LogoImages.ToList()[0].ImagePath = entity.LogoImages.ToList()[0].ImagePath;
                }
                else if (companyInfo.LogoImages.Count == 0 && entity.LogoImages != null && entity.LogoImages.Count > 0)
                {
                    Image image = new Image();
                    image.ImagePath = entity.LogoImages.ToList()[0].ImagePath;
                    image.CompanyInfoID = companyInfo.CompanyInfoID;
                    imageRepository.Add(image);
                    imageRepository.Save();
                }
                companyInfoRepository.Update(companyInfo);
                companyInfoRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult GetByID(int id)
        {
            try
            {
                CompanyInfo companyInfo = companyInfoRepository.GetById(id);
                CompanyInfoDTO companyInfoDto = new CompanyInfoDTO();
                companyInfoDto.CompanyName = companyInfo.CompanyName;
                companyInfoDto.AboutUs = companyInfo.AboutUs;
                companyInfoDto.Email = companyInfo.Email;
                companyInfoDto.PhoneNumber = companyInfo.PhoneNumber;
                if (companyInfo.Address != null)
                {
                    companyInfoDto.Address = new AddressDTO
                    {
                        AddressStr = companyInfo.Address.AddressStr,
                        AddressTitle = companyInfo.Address.AddressTitle,
                        TownID = companyInfo.Address.TownID,
                        PostalCode = companyInfo.Address.PostalCode
                    };
                }
                return Json(companyInfoDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
    }
}