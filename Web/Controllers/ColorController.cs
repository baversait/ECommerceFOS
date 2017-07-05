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
    public class ColorController : Controller, IService<ColorDTO>
    {
        private IColorRepository colorRepository;

        public ColorController(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        // GET: Color
        public ActionResult Index()
        {
            var colors = colorRepository.GetAll()
                .Select(x => new ColorDTO()
                {
                    ColorID = x.ColorID,
                    ColorName = x.ColorName
                })
                .ToList();
            return Json(colors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(ColorDTO entity)
        {
            try
            {
                Color color = new Color()
                {
                    ColorName = entity.ColorName
                };
                colorRepository.Add(color);
                colorRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);

            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Delete(ColorDTO entity)
        {
            try
            {
                Color color = colorRepository.GetById(entity.ColorID);
                colorRepository.Delete(color);
                colorRepository.Save();
                return Json(entity, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult Edit(ColorDTO entity)
        {
            try
            {
                Color color = colorRepository.GetById(entity.ColorID);
                color.ColorName = entity.ColorName;
                colorRepository.Update(color);
                colorRepository.Save();
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
                ColorDTO colorDto = colorRepository.GetAll()
                    .Where(x => x.ColorID == id)
                    .Select(x => new ColorDTO()
                    {
                        ColorID = x.ColorID,
                        ColorName = x.ColorName
                    })
                    .FirstOrDefault();
                return Json(colorDto, JsonRequestBehavior.DenyGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.DenyGet);
            }
        }
    }
}