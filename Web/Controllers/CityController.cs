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
    public class CityController : Controller, IService<CityDTO>
    {
        private ICityRepository cityRepository;
        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        // GET: City
        public ActionResult Index()
        {
            var cities = cityRepository.GetAll()
                .Select(x => new CityDTO()
                {
                    CityID = x.CityID,
                    Name = x.Name,
                    CountryID = x.CountryID,
                    Towns = x.Towns.Select(y => new TownDTO()
                    {
                        TownID = y.TownID,
                        CityID = y.CityID,
                        Name = y.Name
                    })
                        .ToList(),
                    CountryName = x.Country.Name

                });
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add(CityDTO entity)
        {
            try
            {
                City c = new City();
                c.Name = entity.Name;
                c.CountryID = entity.CountryID;
                cityRepository.Add(c);
                cityRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }

        }
        public ActionResult Delete(CityDTO entity)
        {
            try
            {
                City c = cityRepository.GetById(entity.CityID);
                cityRepository.Delete(c);
                cityRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Edit(CityDTO entity)
        {
            try
            {
                City c = cityRepository.GetById(entity.CityID);
                c.Name = entity.Name;
                c.CountryID = entity.CountryID;
                cityRepository.Update(c);
                cityRepository.Save();
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
                City c = cityRepository.GetById(id);
                CityDTO cityDto = new CityDTO();
                cityDto.CityID = c.CityID;
                cityDto.Name = c.Name;
                cityDto.CountryID = c.CountryID;
                cityDto.Towns = c.Towns.Select(y => new TownDTO()
                {
                    TownID = y.TownID,
                    CityID = y.CityID,
                    Name = y.Name
                })
                    .ToList();
                Country country = c.Country;
                cityDto.Country.CountryID = country.CountryID;
                cityDto.Country.Name = country.Name;
                return Json(cityDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCitiesByCountryID(int id)
        {
            try
            {
                var cities = cityRepository.GetAll().Where(x => x.CountryID == id).ToList();
                var citiesDTO = Mapper.Map<List<CityDTO>>(cities);
                return Json(citiesDTO, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}