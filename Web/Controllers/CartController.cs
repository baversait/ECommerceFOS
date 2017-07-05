using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Data.Repositories;
using Model.Models;
using Web.AuthorizationFilters;
using Web.Models;
using Web.Models.DTOs;

namespace Web.Controllers
{
    public class CartController : BaseController
    {
        private ICartRepository cartRepository;
        private ICartDetailRepository cartDetailRepository;
        private IUserRepository userRepository;
        private IProductDetailRepository productDetailRepository;
        private IProductRepository productRepository;

        public CartController(
            ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            ICartRepository cartRepository,
            ICartDetailRepository cartDetailRepository,
            IUserRepository userRepository,
            IProductDetailRepository productDetailRepository,
            IProductRepository productRepository) : base(new CartModel(),
                currencyRepository,
                companyInfoRepository,
                categoryRepository,
                brandRepository)
        {
            this.cartRepository = cartRepository;
            this.cartDetailRepository = cartDetailRepository;
            this.userRepository = userRepository;
            this.productDetailRepository = productDetailRepository;
            this.productRepository = productRepository;
        }

        // GET: Cart
        [UserAuthorization]
        public ActionResult Index()
        {
            CartDTO cart = GetCartDto();
            if (cart == null)
            {
                return Redirect("/");
            }
            CartModel model = (CartModel)mainModel;
            return View(model);
        }


        public ActionResult GetCart()
        {
            User user;
            Cart cart;
            if (Session["user"] != null)
            {
                user = (User)Session["user"];
                var curUser = userRepository.GetById(user.UserID);
                if (curUser.Carts.Count > 0)
                {
                    cart = curUser.Carts.ToList()[0];
                }
                else
                {
                    cart = new Cart { CustomerID = curUser.UserID };
                    cartRepository.Add(cart);
                    cartRepository.Save();
                }
                var cartDto = Mapper.Map<CartDTO>(cart);
                cartDto.NumberOfItems = cartDto.CartDetails.Count;
                if (cartDto.CartDetails.Count > 0)
                {
                    decimal totalPrice = 0;
                    decimal totalTax = 0;

                    foreach (var cartDetail in cartDto.CartDetails)
                    {
                        totalPrice += (cartDetail.UnitPrice * cartDetail.Quantity);
                        ProductDetail p = productDetailRepository.GetById(cartDetail.ProductDetailID);
                        if (p.Product.TaxRate != null)
                        {
                            totalTax += (cartDetail.UnitPrice * (decimal)p.Product.TaxRate / 100 * cartDetail.Quantity);
                        }
                    }
                    cartDto.TotalPrice = totalPrice;
                    cartDto.TotalTax = totalTax;
                    cartDto.TotalPriceAfterTax = totalPrice + totalTax;
                }
                Session["cartID"] = cartDto.CartID;
                return Json(cartDto, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddProductToCart(int productDetailID, int quantity = 1)
        {
            if (Session["cartID"] != null && quantity > 0)
            {
                Cart cart = cartRepository.GetById((int)Session["cartID"]);
                ProductDetail productDetail = productDetailRepository.GetById(productDetailID);

                CartDetail cd = cartDetailRepository.GetByTwoId(cart.CartID, productDetail.ProductDetailID);
                var message = "";
                try
                {
                    if (cd != null)
                    {
                        cd.UnitPrice = productDetail.UnitPrice;
                        cd.AddedAt = DateTime.Now;
                        cd.Quantity += quantity;
                        cartDetailRepository.Update(cd);
                    }
                    else
                    {
                        cd = new CartDetail
                        {
                            CartID = cart.CartID,
                            ProductDetailID = productDetail.ProductDetailID,
                            UnitPrice = productDetail.UnitPrice,
                            Quantity = quantity
                        };
                        cartDetailRepository.Add(cd);
                    }
                    cartDetailRepository.Save();
                    message = $"{quantity} {productDetail.Product.ProductName}(s) successfully added to your cart!";
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
                catch (Exception e)
                {
                    message = e.Message;
                    return Json(message, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteProductFromCart(CartDetailDTO cd)
        {
            string message = "";
            CartDetail cartDetail = cartDetailRepository.GetByTwoId(cd.CartID, cd.ProductDetailID);
            string productName = cartDetail.ProductDetail.Product.ProductName;
            if (cartDetail != null)
            {
                cartDetailRepository.Delete(cartDetail);
                cartDetailRepository.Save();
                message = $"{productName} successfully deleted from your cart!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            message = "Product did not found in your cart";
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateCartDetail(CartDetailDTO cd)
        {
            string message = "";
            if (cd.Quantity < 0)
            {
                message = $"Please enter positive number";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            CartDetail cartDetail = cartDetailRepository.GetByTwoId(cd.CartID, cd.ProductDetailID);
            cartDetail.Quantity = cd.Quantity;
            string productName = cartDetail.ProductDetail.Product.ProductName;
            int oldQuantity = cartDetail.Quantity;
            if (cartDetail != null)
            {
                cartDetailRepository.Update(cartDetail);
                cartDetailRepository.Save();
                message = $"{oldQuantity} {productName}(s) successfully updated to {cartDetail.Quantity}!";
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            message = "Product did not found in your cart";
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public CartDTO GetCartDto()
        {
            User user;
            Cart cart;
            if (Session["user"] != null)
            {
                user = (User)Session["user"];
                var curUser = userRepository.GetById(user.UserID);
                if (curUser.Carts.Count > 0)
                {
                    cart = curUser.Carts.ToList()[0];
                }
                else
                {
                    cart = new Cart { CustomerID = curUser.UserID };
                    cartRepository.Add(cart);
                    cartRepository.Save();
                }
                var cartDto = Mapper.Map<CartDTO>(cart);
                cartDto.NumberOfItems = cartDto.CartDetails.Count;
                if (cartDto.CartDetails.Count > 0)
                {
                    decimal totalPrice = 0;
                    decimal totalTax = 0;

                    foreach (var cartDetail in cartDto.CartDetails)
                    {
                        totalPrice += cartDetail.TotalPrice;
                        ProductDetail p = productDetailRepository.GetById(cartDetail.ProductDetailID);
                        if (p.Product.TaxRate != null)
                        {
                            totalTax += p.UnitPrice * (decimal)p.Product.TaxRate / 100;
                        }
                    }
                    cartDto.TotalPrice = totalPrice;
                    cartDto.TotalTax = totalTax;
                    cartDto.TotalPriceAfterTax = totalPrice + totalTax;
                }
                return cartDto;
            }
            return null;
        }
    }
}