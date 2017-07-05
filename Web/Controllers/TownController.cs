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
    public class TownController : Controller, IService<TownDTO>
    {
        private ITownRepository townRepository;
        public TownController(ITownRepository townRepository)
        {
            this.townRepository = townRepository;
        }

        // GET: Town
        public ActionResult Index()
        {
            var towns = townRepository.GetAll()
                .Select(x => new TownDTO()
                {
                    TownID = x.TownID,
                    Name = x.Name,
                    CityID = x.CityID,
                    CityName = x.City.Name
                })
                .ToList();

            return Json(towns, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(TownDTO entity)
        {
            try
            {
                Town t = new Town();
                t.Name = entity.Name;
                t.CityID = entity.CityID;
                townRepository.Add(t);
                townRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult Delete(TownDTO entity)
        {
            try
            {
                Town t = townRepository.GetById(entity.TownID);
                townRepository.Delete(t);
                townRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult Edit(TownDTO entity)
        {
            try
            {
                Town c = townRepository.GetById(entity.TownID);
                c.Name = entity.Name;
                c.CityID = entity.CityID;
                townRepository.Update(c);
                townRepository.Save();
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
                Town town = townRepository.GetById(id);
                TownDTO townDto = new TownDTO();
                townDto.TownID = town.TownID;
                townDto.Name = town.Name;
                townDto.CityID = town.CityID;
                townDto.City.CityID = town.City.CityID;
                townDto.City.Name = town.City.Name;
                townDto.City.CountryID = town.City.CountryID;
                return Json(townDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetTownByCityID(int id)
        {
            try
            {
                var towns = townRepository.GetAll().Where(x => x.CityID == id).ToList();
                var townsDTO = Mapper.Map<List<TownDTO>>(towns);
                return Json(townsDTO, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}