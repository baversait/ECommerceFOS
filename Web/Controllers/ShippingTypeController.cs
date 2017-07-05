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
    public class ShippingTypeController : Controller, IService<ShippingTypesDTO>
    {
        private IShippingTypeRepository shippingTypeRepository;
        public ShippingTypeController(IShippingTypeRepository shippingTypeRepository)
        {
            this.shippingTypeRepository = shippingTypeRepository;
        }

        // GET: ShippingTypes
        public ActionResult Index()
        {
            //try
            //{
            //    List<ShippingTypesDTO> shippingType = shippingTypeRepository.GetAll().Select(x => new ShippingTypesDTO
            //    {
            //        ShippingTypeID = x.ShippingTypeID,
            //        Name = x.Name,
            //        Description = x.Description,
            //        PricePerDeci = x.PricePerDeci
            //    }).ToList();

            //    if (shippingType.Capacity == 0)
            //    {
            //        shippingType = new List<ShippingTypesDTO> { new ShippingTypesDTO() };
            //    }

            //    return Json(shippingType, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception e)
            //{

            //    return Json(false, JsonRequestBehavior.DenyGet);
            //}

            var shippingType = shippingTypeRepository.GetAll().ToList();
            var shippingTypeDTO = Mapper.Map<List<ShippingType>, List<ShippingTypesDTO>>(shippingType);
            return Json(shippingTypeDTO, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Add(ShippingTypesDTO entity)
        {
            //try
            //{
            //    ShippingType s = shippingTypeRepository.GetById(entity.ShippingTypeID);
            //    shippingTypeRepository.Add(s);
            //    shippingTypeRepository.Save();

            //    return Json(entity, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception e)
            //{
            //    return Json(false, JsonRequestBehavior.DenyGet);                
            //}

            ShippingType shippingType = Mapper.Map<ShippingTypesDTO, ShippingType>(entity);
            shippingTypeRepository.Add(shippingType);
            shippingTypeRepository.Save();
            return Json(entity, JsonRequestBehavior.AllowGet);

        }      
        [HttpPost]
        public ActionResult Delete(ShippingTypesDTO entity)
        {
            try
            {
                ShippingType s = shippingTypeRepository.GetById(entity.ShippingTypeID);
                shippingTypeRepository.Delete(s);
                shippingTypeRepository.Save();

                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
            

        }

        public ActionResult Edit(ShippingTypesDTO entity)
        {
            //try
            //{
            //    ShippingType s = shippingTypeRepository.GetById(entity.ShippingTypeID);
            //    s.Name = entity.Name;
            //    s.Description = entity.Description;
            //    s.PricePerDeci = entity.PricePerDeci;
            //    shippingTypeRepository.Update(s);
            //    shippingTypeRepository.Save();

            //    return Json(entity, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception e)
            //{

            //    return Json(false, JsonRequestBehavior.DenyGet);
            //}

            ShippingType shippingType = Mapper.Map<ShippingTypesDTO, ShippingType>(entity);
            shippingTypeRepository.Update(shippingType);
            shippingTypeRepository.Save();
            return Json(entity, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetByID(int id)
        {
            try
            {
                ShippingType s = shippingTypeRepository.GetById(id);
                ShippingTypesDTO shippingDto = new ShippingTypesDTO
                {
                    ShippingTypeID = s.ShippingTypeID,
                    Name = s.Name,
                    Description = s.Description,
                    PricePerItem = s.PricePerItem
                };

                return Json(shippingDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

                return Json(false, JsonRequestBehavior.DenyGet);
            }
            
        }

       
    }
}