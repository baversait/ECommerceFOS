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
    public class CategoryController : Controller, IService<CategoryDTO>
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryRepository.GetAll().ToList();
            var categoriesDTO = Mapper.Map<List<Category>, List<CategoryDTO>>(categories);

            return Json(categoriesDTO, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(CategoryDTO entity)
        {
            try
            {
                //Category c = new Category();
                //c.CategoryName = entity.CategoryName;
                //c.Description = entity.Description;
                Category c = Mapper.Map<CategoryDTO, Category>(entity);

                categoryRepository.Add(c);
                categoryRepository.Save();
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(entity, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public ActionResult Delete(CategoryDTO entity)
        {
            try
            {
                Category c = categoryRepository.GetById(entity.CategoryID);
                categoryRepository.Delete(c);
                categoryRepository.Save();
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Edit(CategoryDTO entity)
        {
            try
            {
                Category c = categoryRepository.GetById(entity.CategoryID);
                //c.CategoryName = entity.CategoryName;
                //c.Description = entity.Description;
                Mapper.Map<CategoryDTO, Category>(entity, c);
                categoryRepository.Update(c);
                categoryRepository.Save();
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetByID(int id)
        {
            try
            {
                Category category = categoryRepository.GetById(id);
                CategoryDTO categoryDto = new CategoryDTO
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                return Json(categoryDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


    }
}