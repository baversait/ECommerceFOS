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
    public class BrandController : Controller, IService<BrandDTO>
    {
        private IBrandRepository brandRepository;
        private IImageRepository imageRepository;

        public BrandController(IBrandRepository brandRepository,
            IImageRepository imageRepository)
        {
            this.brandRepository = brandRepository;
            this.imageRepository = imageRepository;
        }

        // GET: Brand
        public ActionResult Index()
        {
            var brands = brandRepository.GetAll().ToList();
            var brandDTOs = Mapper.Map<List<BrandDTO>>(brands);
            return Json(brandDTOs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(BrandDTO entity)
        {
            try
            {
                Brand brand = Mapper.Map<Brand>(entity);

                brandRepository.Add(brand);
                brandRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(BrandDTO entity)
        {
            try
            {
                Brand brand = brandRepository.GetById(entity.BrandID);
                brandRepository.Delete(brand);
                brandRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult Edit(BrandDTO entity)
        {
            try
            {
                Brand brand = brandRepository.GetById(entity.BrandID);
                brand.BrandName = entity.BrandName;
                brand.Info = entity.Info;
                brand.Website = entity.Website;
                brand.Address.AddressID = entity.Address.AddressID;
                brand.Address.AddressTitle = entity.Address.AddressTitle;
                brand.Address.AddressStr = entity.Address.AddressStr;
                brand.Address.PostalCode = entity.Address.PostalCode;
                brand.Address.TownID = entity.Address.TownID;
                if (brand.Images.Count > 0 && entity.Images != null && entity.Images.Count > 0)
                {
                    brand.Images.ToList()[0].ImagePath = entity.Images.ToList()[0].ImagePath;
                }
                else if (brand.Images.Count == 0 && entity.Images != null && entity.Images.Count > 0)
                {
                    Image image = new Image();
                    image.ImagePath = entity.Images.ToList()[0].ImagePath;
                    image.BrandID = brand.BrandID;
                    imageRepository.Add(image);
                    imageRepository.Save();
                }
                brandRepository.Update(brand);
                brandRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult GetByID(int id)
        {
            var brands = brandRepository.GetAll()
                .Where(x => x.BrandID == id)
                .Select(x => new BrandDTO()
                {
                    BrandID = x.BrandID,
                    BrandName = x.BrandName,
                    Info = x.Info,
                    Website = x.Website,
                    AddressID = x.AddressID,
                    Address = new AddressDTO()
                    {
                        AddressID = x.Address.AddressID,
                        AddressTitle = x.Address.AddressTitle,
                        AddressStr = x.Address.AddressStr,
                        PostalCode = x.Address.PostalCode,
                        TownName = x.Address.Town.Name,
                        TownID = x.Address.TownID,
                        CityID = x.Address.Town.CityID,
                        CountryID = x.Address.Town.City.CountryID
                    }
                })
                .FirstOrDefault();
            return Json(brands, JsonRequestBehavior.AllowGet);
        }
    }
}