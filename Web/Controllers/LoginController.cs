using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories;
using Model.Models;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : BaseController
    {
        private IUserRepository userRepository;

        public LoginController(
            ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IUserRepository userRepository) :
            base(
                new MainModel(),
                currencyRepository,
            companyInfoRepository,
            categoryRepository,
            brandRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View(mainModel);
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email != null && password != null)
            {
                User user = userRepository.Get(x => x.Email.Equals(email) && x.Password.Equals(password));
                if (user != null)
                {
                    Session["user"] = user;
                    Session["userName"] = user.Name + " " + user.LastName;
                    Session["userRole"] = user.Role;
                    if (user.Role.Equals("admin"))
                    {
                        return Redirect("/admin/Admin");
                    }
                    return Redirect("/");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {

            if (Session["user"] != null)
            {
                Session["user"] = null;
                Session["userName"] = null;
                Session["userRole"] = null;
            }

            return Redirect("/");
        }
    }
}