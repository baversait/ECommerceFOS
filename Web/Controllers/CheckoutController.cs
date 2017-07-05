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
    public class CheckoutController : BaseController
    {
        private IShippingTypeRepository shippingTypeRepository;
        private IOrderRepository orderRepository;
        private ICartRepository cartRepository;
        private IOrderDetailRepository orderDetailRepository;

        public CheckoutController(
            ICurrencyRepository currencyRepository,
            ICompanyInfoRepository companyInfoRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IShippingTypeRepository shippingTypeRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            ICartRepository cartRepository) : base(new CheckoutModel(),
                currencyRepository,
                companyInfoRepository,
                categoryRepository,
                brandRepository)
        {
            this.shippingTypeRepository = shippingTypeRepository;
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
            this.cartRepository = cartRepository;
        }

        // GET: Checkout
        [UserAuthorization]
        public ActionResult Index()
        {
            var shippingTypes = shippingTypeRepository.GetAll().ToList();
            var model = (CheckoutModel)mainModel;
            model.ShippingTypes = Mapper.Map<List<ShippingTypesDTO>>(shippingTypes);
            return View(model);
        }

        public ActionResult BestSellers()
        {
            var bestSellerProducts = orderRepository.GetBestSellers();
            var bestSellerProductDTOs = Mapper.Map<List<ProductDetailDTO>>(bestSellerProducts);
            return Json(bestSellerProductDTOs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [UserAuthorization]
        public ActionResult Order(GiveOrderDTO giveOrderDto)
        {
            if (Session["user"] != null)
            {
                try
                {
                    User user = (User)Session["user"];
                    Order order = new Order
                    {
                        CustomerID = user.UserID,
                        Notes = giveOrderDto.Notes,
                        Address = Mapper.Map<Address>(giveOrderDto.ShippingAddress),
                        ShippingTypeID = giveOrderDto.ShippingTypeID
                    };
                    orderRepository.Add(order);
                    orderRepository.Save();

                    Cart cart = cartRepository.GetById(giveOrderDto.CartID);
                    foreach (var cartDetail in cart.CartDetails)
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            ProductDetailID = cartDetail.ProductDetailID,
                            OrderID = order.OrderID,
                            Quantity = cartDetail.Quantity,
                            Discount = cartDetail.Discount,
                            UnitPrice = cartDetail.UnitPrice
                        };
                        orderDetailRepository.Add(orderDetail);
                        orderDetailRepository.Save();
                    }
                    cartRepository.Delete(cart);
                    cartRepository.Save();


                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }
            return Redirect("/");
        }
    }
}