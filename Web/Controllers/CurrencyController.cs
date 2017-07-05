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
    public class CurrencyController : Controller, IService<CurrencyDTO>
    {
        private ICurrencyRepository currencyRepository;
        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            this.currencyRepository = currencyRepository;
        }

        // GET: Currency
        public ActionResult Index()
        {
            List<CurrencyDTO> currencies = currencyRepository.GetAll().Select(x => new CurrencyDTO
            {
                CurrencyID = x.CurrencyID,
                CurrencyName = x.CurrencyName,
                Value = x.Value,
                CurrencySymbol = x.CurrencySymbol,
                Date = x.Date.ToShortDateString()
            }).ToList();

            if (currencies.Capacity == 0)
            {
                currencies = new List<CurrencyDTO> { new CurrencyDTO() };
            }

            return Json(currencies, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(CurrencyDTO currency)
        {
            Currency c = new Currency();
            c.CurrencyName = currency.CurrencyName;
            c.CurrencySymbol = currency.CurrencySymbol;
            c.Date = Convert.ToDateTime(currency.Date);
            c.Value = currency.Value;

            currencyRepository.Add(c);
            currencyRepository.Save();

            return Json(currency, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult Delete(CurrencyDTO currency)
        {
            Currency c = currencyRepository.GetById(currency.CurrencyID);
            currencyRepository.Delete(c);
            currencyRepository.Save();
            return Json(currency, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public ActionResult Edit(CurrencyDTO currency)
        {
            Currency c = currencyRepository.GetById(currency.CurrencyID);
            c.CurrencyName = currency.CurrencyName;
            c.CurrencySymbol = currency.CurrencySymbol;
            c.Date = Convert.ToDateTime(currency.Date);
            c.Value = currency.Value;

            currencyRepository.Update(c);
            currencyRepository.Save();
            return Json(currency, JsonRequestBehavior.DenyGet);
        }

        public ActionResult GetByID(int id)
        {
            var currency = currencyRepository.GetById(id);
            CurrencyDTO currencyDto = new CurrencyDTO
            {
                CurrencyID = currency.CurrencyID,
                CurrencyName = currency.CurrencyName,
                CurrencySymbol = currency.CurrencySymbol,
                Value = currency.Value,
                Date = currency.Date.ToShortDateString()
            };
            return Json(currencyDto, JsonRequestBehavior.AllowGet);
        }
    }


}