using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CakeShop.Controllers.Api
{
    public class CartsController : ApiController
    {
        private ApplicationDbContext _context;

        public CartsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/carts
        public IEnumerable<Cart> GetCarts()
        {
            return _context.Carts.ToList();
        }

        //GET /api/carts/1
        public Cart GetCart(int id)
        {
            var cart = _context.Carts.SingleOrDefault(c => c.Id == id);

            if (cart == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return cart;
        }

        //POST /api/carts
        [HttpPost]
        public Cart CreateCart(Cart cart)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Carts.Add(cart);
            _context.SaveChanges();

            return cart;
        }

        //PUT /api/carts/1
        [HttpPut]
        public void UpdateCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cartInDb = _context.Carts.SingleOrDefault(c => c.Id == cart.Id);

            if (cartInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            cartInDb.Cantitate = cart.Cantitate;


            _context.SaveChanges();
        }

        //DELETE /api/carts/1
        [HttpDelete]
        public void DeleteCart(int id)
        {
            var cartInDb = _context.Carts.SingleOrDefault(c => c.Id == id);

            if (cartInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Carts.Remove(cartInDb);
            _context.SaveChanges();
        }

    }
}
