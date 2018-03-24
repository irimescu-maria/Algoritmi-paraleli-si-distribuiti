using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CakeShop.Controllers.Api
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/orders
        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        //GET /api/orders/1
        public Order GetOrder(int id)
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == id);

            if (order == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return order;
        }

        //POST /api/orders
        [HttpPost]
        public Order CreateOrder(Order order)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        //PUT /api/orders/1
        [HttpPut]
        public void UpdateOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var orderInDb = _context.Orders.SingleOrDefault(o=>o.Id == order.Id);

            if (orderInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            orderInDb.Username = order.Username;
            orderInDb.FirstName = order.FirstName;
            orderInDb.LastName = order.LastName;
            orderInDb.Address = order.Address;
            orderInDb.PostalCode = order.PostalCode;
            orderInDb.Phone = order.Phone;
            orderInDb.Email = order.Email;
            orderInDb.Total = order.Total;
            orderInDb.OrderDate = order.OrderDate;
            orderInDb.City = order.City;
            orderInDb.County = order.County;


            _context.SaveChanges();


        }

        //DELETE /api/orders/1
        public void DeleteOrder(int id)
        {
            var orderInDb = _context.Orders.SingleOrDefault(o=>o.Id == id);

            if (orderInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Orders.Remove(orderInDb);
            _context.SaveChanges();
        }
    }
}
