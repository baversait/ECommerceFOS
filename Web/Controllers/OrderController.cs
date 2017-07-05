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
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // GET: Order
        [HttpPost]
        public ActionResult Index()
        {
            var orders = orderRepository.GetAll().ToList();
            var orderDTOs = Mapper.Map<List<OrderDTO>>(orders);
            return Json(orderDTOs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateShippedStatus(OrderDTO entity)
        {
            Order order = orderRepository.GetById(entity.OrderID);
            order.ShippedDate = DateTime.Now;
            orderRepository.Update(order);
            orderRepository.Save();
            return Json(entity, JsonRequestBehavior.AllowGet);
        }
    }
}