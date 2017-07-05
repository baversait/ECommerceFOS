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
    public class ImageController : Controller, IService<ImageDTO>
    {
        private IImageRepository imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(ImageDTO entity)
        {
            try
            {
                Image image = Mapper.Map<Image>(entity);
                imageRepository.Add(image);
                imageRepository.Save();
                return Json(image, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Delete(ImageDTO entity)
        {
            try
            {
                Image image = imageRepository.GetById(entity.ImageID);
                imageRepository.Delete(image);
                imageRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Edit(ImageDTO entity)
        {
            try
            {
                Image image = imageRepository.GetById(entity.ImageID);
                Mapper.Map(entity, image);
                imageRepository.Update(image);
                imageRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}