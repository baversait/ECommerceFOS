using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories;
using Model.Models;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class CountryController : Controller, IService<CountryDTO>
    {
        private ICountryRepository countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        // GET: Country
        public ActionResult Index()
        {
            var countries = countryRepository.GetAll()
                .Select(x => new CountryDTO()
                {
                    Name = x.Name,
                    CountryID = x.CountryID,
                    Cities = x.Cities.Select(y => new CityDTO()
                        {
                            CityID = y.CityID,
                            Name = y.Name
                        })
                        .ToList()
                    
                });
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(CountryDTO entity)
        {
            try
            {
                Country country = new Country
                {
                    Name = entity.Name
                };
                countryRepository.Add(country);
                countryRepository.Save();
                return Json(country, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                
            }
            
            return Json(false, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult Delete(CountryDTO entity)
        {
            try
            {
                Country c = countryRepository.GetById(entity.CountryID);
                countryRepository.Delete(c);
                countryRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpPost]
        public ActionResult Edit(CountryDTO entity)
        {
            try
            {
                Country c = countryRepository.GetById(entity.CountryID);
                c.Name = entity.Name;
                countryRepository.Update(c);
                countryRepository.Save();
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
                Country c = countryRepository.GetById(id);
                CountryDTO countryDto = new CountryDTO();
                countryDto.CountryID = c.CountryID;
                countryDto.Name = c.Name;
                countryDto.Cities = c.Cities.Select(y => new CityDTO()
                    {
                        CityID = y.CityID,
                        Name = y.Name
                    })
                    .ToList();
                return Json(countryDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
    }
}