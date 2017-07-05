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
    public class SubCategoryController : Controller, IService<SubCategoryDTO>
    {
        private ISubCategoryRepository subCategoryRepository;
        public SubCategoryController(ISubCategoryRepository subCategoryRepository)
        {
            this.subCategoryRepository = subCategoryRepository;
        }
        // GET: SubCategory
        public ActionResult Index()
        {
            //List<SubCategoryDTO> subCategory = subCategoryRepository.GetAll().Select(x => new SubCategoryDTO
            //{
            //    CategoryID = x.CategoryID,
            //    CategoryName = x.Category.CategoryName,
            //    Description = x.Description,
            //    SubCategoryID = x.SubCategoryID,
            //    SubCategoryName = x.SubCategoryName
            //}).ToList();

            //if (subCategory.Capacity == 0)
            //{
            //    subCategory = new List<SubCategoryDTO> { new SubCategoryDTO() };
            //}

            List<SubCategory> subCategory = subCategoryRepository.GetAll().ToList();
            List<SubCategoryDTO> subCategoryDtos = Mapper.Map<List<SubCategory>, List<SubCategoryDTO>>(subCategory);

            return Json(subCategoryDtos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(SubCategoryDTO entity)
        {
            try
            {
                //SubCategory subCat = new SubCategory();
                //subCat.CategoryID = entity.CategoryID;
                //subCat.Description = entity.Description;
                //subCat.SubCategoryName = entity.SubCategoryName;

                SubCategory subCat = Mapper.Map<SubCategoryDTO, SubCategory>(entity);

                subCategoryRepository.Add(subCat);
                subCategoryRepository.Save();

                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(entity, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult Delete(SubCategoryDTO entity)
        {
            try
            {
                SubCategory subCat = subCategoryRepository.GetById(entity.SubCategoryID);
                subCategoryRepository.Delete(subCat);
                subCategoryRepository.Save();
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Edit(SubCategoryDTO entity)
        {
            try
            {
                SubCategory subCat = subCategoryRepository.GetById(entity.SubCategoryID);
                //subCat.CategoryID = entity.CategoryID;
                //subCat.SubCategoryName = entity.SubCategoryName;
                //subCat.Description = entity.Description;
                Mapper.Map(entity, subCat);

                subCategoryRepository.Update(subCat);
                subCategoryRepository.Save();
                return Json(entity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetByID(int id)
        {
            try
            {
                SubCategory subCat = subCategoryRepository.GetById(id);
                SubCategoryDTO subCategoryDto = Mapper.Map<SubCategoryDTO>(subCat);

                return Json(subCategoryDto, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSubCategoriesByCategoryID(int id)
        {
            try
            {
                var subCats = subCategoryRepository.GetAll()
                    .Where(x => x.CategoryID == id)
                    .Select(subCat => new SubCategoryDTO()
                    {
                        SubCategoryID = subCat.SubCategoryID,
                        CategoryID = subCat.CategoryID,
                        SubCategoryName = subCat.SubCategoryName,
                        Description = subCat.Description
                    })
                    .ToList();

                return Json(subCats, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}