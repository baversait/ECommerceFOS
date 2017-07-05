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
    public class CouponController : Controller, IService<CouponsDTO>
    {
        private ICouponRepository couponRepository;
        private ICartRepository cartRepository;
        private ICartDetailRepository cartDetailRepository;

        public CouponController(ICouponRepository couponRepository, ICartRepository cartRepository, ICartDetailRepository cartDetailRepository)
        {
            this.couponRepository = couponRepository;
            this.cartRepository = cartRepository;
            this.cartDetailRepository = cartDetailRepository;
        }

        // GET: Coupon
        public ActionResult Index()
        {
            var coupons = couponRepository.GetAll().ToList();
            var couponDTO = Mapper.Map<List<Coupons>, List<CouponsDTO>>(coupons);
            return Json(couponDTO, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(CouponsDTO entity)
        {

            Coupons c = Mapper.Map<CouponsDTO, Coupons>(entity);
            couponRepository.Add(c);
            couponRepository.Save();
            return Json(entity, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(CouponsDTO entity)
        {
            Coupons c = Mapper.Map<CouponsDTO, Coupons>(entity);
            couponRepository.Delete(c);
            return Json(entity, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(CouponsDTO entity)
        {
            Coupons c = couponRepository.GetById(entity.CouponID);
            Mapper.Map<CouponsDTO, Coupons>(entity, c);

            couponRepository.Update(c);
            couponRepository.Save();

            return Json(entity, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByID(int id)
        {
            //Coupons coupon = couponRepository.GetById(id);
            //CouponsDTO couponDto = new CouponsDTO
            //{
            //    CouponID=coupon.CouponID,
            //    CouponCode=coupon.CouponCode,
            //    Counts=coupon.Counts,
            //    Remaining=coupon.Remaining,
            //    ExpiresAt=coupon.ExpiresAt,
            //    CategoryName=coupon.Category.CategoryName,
            //    CustomerName=coupon.User.Name+coupon.User.LastName
            //};

            return Json(false, JsonRequestBehavior.DenyGet);
        }

        public ActionResult ApplyCouponToCart(int cartID, string couponCode)
        {
            string message = "";
            Cart cart = cartRepository.GetById(cartID);
            Coupons coupon = couponRepository.Get(x => x.CouponCode.Equals(couponCode));
            if (cart != null && coupon != null)
            {
                if (coupon.ExpiresAt < DateTime.Now)
                {
                    message = $"Coupon already expired!";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
                if (coupon.CustomerID != null && Session["user"] != null)
                {
                    User loggedInUser = (User)Session["user"];
                    if (coupon.CustomerID != loggedInUser.UserID)
                    {
                        message = "You are not authorized to use this coupon";
                        return Json(message, JsonRequestBehavior.AllowGet);
                    }
                }
                if (coupon.Remaining < 1)
                {
                    message = $"All the coupons defined to couponCode:{couponCode} have used!";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
                bool doesUserHaveItemInTheCartFromCouponsCategory = false;
                bool didCouponUsed = false;
                foreach (var cartDetail in cart.CartDetails)
                {
                    if (coupon.CategoryID != null)
                    {
                        if (cartDetail.ProductDetail.Product.SubCategoryID == coupon.CategoryID)
                        {
                            cartDetail.UnitPrice *= ((100 - coupon.Discount) / 100);
                            cartDetailRepository.Update(cartDetail);
                            cartDetailRepository.Save();
                            didCouponUsed = true;
                            doesUserHaveItemInTheCartFromCouponsCategory = true;
                        }
                    }
                    else
                    {
                        cartDetail.UnitPrice *= ((100 - coupon.Discount) / 100);
                        cartDetailRepository.Update(cartDetail);
                        cartDetailRepository.Save();
                        didCouponUsed = true;
                    }

                }
                if (coupon.CategoryID != null &&
                    doesUserHaveItemInTheCartFromCouponsCategory)
                {
                    message =
                        $"You can't use this coupon due you don't have item in your cart from coupons category!";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
                if (didCouponUsed)
                {
                    message = "Coupon successfully applied to your cart";
                    if (coupon.Remaining != null)
                    {
                        coupon.Remaining--;
                        couponRepository.Update(coupon);
                        couponRepository.Save();
                    }
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (cart == null)
                {
                    message = $"Cart with id of {cartID} did not found in the database!";
                }
                if (coupon == null)
                {
                    message = $"Coupon with couponCode of {couponCode} did not found in the database!";
                }
                return Json(message, JsonRequestBehavior.AllowGet);
            }



            return Json(false, JsonRequestBehavior.AllowGet);
        }


    }
}