using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories;
using Web.Models;
using System.Net;
using System.Net.Mail;

namespace Web.Controllers
{
    public class ContactUsPageController : BaseController
    {
        
        public ContactUsPageController( 
            ICurrencyRepository currencyRepository, 
            ICompanyInfoRepository companyInfoRepository, 
            ICategoryRepository categoryRepository, 
            IBrandRepository brandRepository
            ) : base(
                new MainModel(),                
                currencyRepository, 
                companyInfoRepository, categoryRepository, brandRepository)
        {
        
        }

        // GET: ContactUs
        public ActionResult Index()
        {            
            return View(mainModel);
        }

        
        [HttpPost]
        public ActionResult SendEmail(string Subject, string Body)
        {
            var fromAddress = new MailAddress("omaktas@gmail.com", "From Name");
            var toAddress = new MailAddress("ofa_2101@hotmail.com", "To Name");

            const string fromPassword = "a";

            
            return View();
        }
    }
}