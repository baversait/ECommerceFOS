using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Web.Models.DTOs;
using Model.Models;

namespace Web.Controllers
{
    public class CompanyController : Controller, IService<CompanyDTO>
    {
        private ICompanyRepository companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        // GET: Company
        public ActionResult Index()
        {
            var companies = companyRepository.GetAll().ToList();
            var company = Mapper.Map<List<Company>, List<CompanyDTO>>(companies);
            return Json(company, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(CompanyDTO entity)
        {
            //Company com = new Company();
            //com.CompanyName = entity.CompanyName;
            //com.ContactName = entity.ContactName;
            //com.ContactTitle = entity.ContactTitle;
            //com.AddressID = entity.AddressID;
            //com.Phone = entity.Phone;
            //com.Fax = entity.Fax;
            //com.Website = entity.Website;
            //com.IsSupplier = entity.IsSupplier;

            //companyRepository.Add(com);
            //companyRepository.Save();

            //return Json(entity, JsonRequestBehavior.AllowGet);

            try
            {
                Company company = Mapper.Map<CompanyDTO, Company>(entity);
                companyRepository.Add(company);
                companyRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(CompanyDTO entity)
        {
            try
            {
                Company com = companyRepository.GetById(entity.CompanyID);
                companyRepository.Delete(com);
                companyRepository.Save();

                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult Edit(CompanyDTO entity)
        {
            try
            {
                Company com = companyRepository.GetById(entity.CompanyID);
                com.CompanyName = entity.CompanyName;
                com.ContactName = entity.ContactName;
                com.ContactTitle = entity.ContactTitle;
                com.Phone = entity.Phone;
                com.Fax = entity.Fax;
                com.Website = entity.Website;
                com.IsSupplier = entity.IsSupplier;
                com.Address.AddressStr = entity.Address.AddressStr;
                com.Address.AddressTitle = entity.Address.AddressTitle;
                com.Address.TownID = entity.Address.TownID;
                com.Address.PostalCode = entity.Address.PostalCode;
                //Mapper.Map<CompanyDTO, Company>(entity, com);
                companyRepository.Update(com);
                companyRepository.Save();

                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetByID(int id)
        {
            try
            {
                Company com = companyRepository.GetById(id);
                CompanyDTO companyDto = new CompanyDTO
                {
                    CompanyID = com.CompanyID,
                    CompanyName = com.CompanyName,
                    ContactName = com.ContactName,
                    ContactTitle = com.ContactTitle,
                    AddressID = com.AddressID,
                    AddressStr = com.Address.AddressStr,
                    Phone = com.Phone,
                    Fax = com.Fax,
                    Website = com.Website,
                    IsSupplier = com.IsSupplier
                };

                return Json(companyDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


    }
}