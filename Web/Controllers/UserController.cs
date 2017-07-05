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
    public class UserController : Controller, IService<UserDTO>
    {
        private IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: User
        public ActionResult Index()
        {
            var user = userRepository.GetAll().ToList();
            var userDTO = Mapper.Map<List<User>, List<UserDTO>>(user);
            return Json(userDTO, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Add(UserDTO entity)
        {

            var user = Mapper.Map<UserDTO, User>(entity);
            userRepository.Add(user);
            userRepository.Save();

            return Json(entity, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Delete(UserDTO entity)
        {

            User user = userRepository.GetById(entity.UserID);
            userRepository.Delete(user);
            userRepository.Save();

            return Json(entity, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Edit(UserDTO entity)
        {
            var user = Mapper.Map<UserDTO, User>(entity);
            userRepository.Update(user);
            userRepository.Save();

            return Json(entity, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult MakeUserAdmin(UserDTO entity)
        {
            var user = userRepository.GetById(entity.UserID);
            user.Role = "admin";
            userRepository.Update(user);
            userRepository.Save();

            return Json(entity, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetByID(int id)
        {

            throw new NotImplementedException();
        }


    }
}