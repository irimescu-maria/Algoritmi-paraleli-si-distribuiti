using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CakeShop.Controllers.Api
{
    public class orderDetailDetailsController : ApiController
    {
        private ApplicationDbContext _context;

        public orderDetailDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/orderDetails
        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        //GET /api/orderDetails/1
        public OrderDetail GetOrderDetail(int id)
        {
            var orderDetail = _context.OrderDetails.SingleOrDefault(o => o.Id == id);

            if (orderDetail == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return orderDetail;
        }

        //POST /api/orderDetails
        [HttpPost]
        public OrderDetail CreateOrderDetail(OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();

            return orderDetail;
        }

        //PUT /api/orderDetails/1
        [HttpPut]
        public void UpdateOrderDetail(int id, OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var orderDetailsInDb = _context.OrderDetails.SingleOrDefault(o => o.Id == orderDetail.Id);

            if (orderDetailsInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            orderDetailsInDb.Quantity = orderDetail.Quantity;
            orderDetailsInDb.UnitPrice = orderDetail.UnitPrice;

            _context.SaveChanges();
        }

        //DELETE /api/orderDetails/1
        public void DeleteOrderDetail(int id)
        {
            var orderDetailsInDb = _context.OrderDetails.SingleOrDefault(o => o.Id == id);

            if (orderDetailsInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.OrderDetails.Remove(orderDetailsInDb);
            _context.SaveChanges();
        }
    }
}
