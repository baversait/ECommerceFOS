using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Data.Repositories;
using Model.Models;
using Web.Models;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class RegisterController : BaseController
    {
        private IUserRepository userRepository;

        public RegisterController(
            ICurrencyRepository currencyRepository, 
            ICompanyInfoRepository companyInfoRepository, 
            ICategoryRepository categoryRepository, 
            IBrandRepository brandRepository, 
            IUserRepository userRepository) : base(new MainModel(), 
                currencyRepository, 
                companyInfoRepository, 
                categoryRepository, 
                brandRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: Register
        public ActionResult Index()
        {
            return View((MainModel) mainModel);
        }

        [HttpPost]
        public ActionResult Register(UserDTO userDto)
        {
            // Email check
            var users = userRepository.GetMany(x => x.Email.Equals(userDto.Email));
            if (users != null && users.Count() != 0)
            {
                return View("Index");
            }

            try
            {
                User user = Mapper.Map<User>(userDto);
                userRepository.Add(user);
                userRepository.Save();

                Session["userName"] = user.Name + " " + user.LastName;
                Session["user"] = user;
                Session["userRole"] = user.Role;
                return Redirect("/");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }

            return Redirect("/");
        }

        
    }
}