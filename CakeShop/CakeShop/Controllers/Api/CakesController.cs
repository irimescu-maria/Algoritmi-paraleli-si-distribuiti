using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CakeShop.Controllers.Api
{
    public class CakesController : ApiController
    {
        private ApplicationDbContext _context;

        public CakesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/cakes
        public IEnumerable<Cake> GetCakes()
        {
            return _context.Cakes.ToList();
        }

        //GET /api/cakes/1
        public Cake GetCake(int id)
        {
            var cake = _context.Cakes.SingleOrDefault(c => c.Id == id);

            if (cake == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return cake;
        }

        //POST /api/cakes
        [HttpPost]
        public Cake CreateCake(Cake cake)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Cakes.Add(cake);
            _context.SaveChanges();
            return cake;
        }

        //PUT /api/cakes/1
        [HttpPut]
        public void UpdateCake(int id,Cake cake)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cakeInDb = _context.Cakes.SingleOrDefault(c => c.Id == cake.Id);

            if (cakeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            cakeInDb.Name = cake.Name;
            cakeInDb.Description = cake.Description;
            cakeInDb.AvailableQuantity = cake.AvailableQuantity;
            cakeInDb.Price = cake.Price;
            cakeInDb.ImagePath = cake.ImagePath;
            cakeInDb.CategoryId = cake.CategoryId;

            //_context.Cakes.Add(cakeInDb);
            _context.SaveChanges();
        }

        //DELETE /api/cakes/1
        [HttpDelete]
        public void DeleteCake(int id)
        {
            var cakeInDb = _context.Cakes.SingleOrDefault(c => c.Id == id);

            if (cakeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Cakes.Remove(cakeInDb);
            _context.SaveChanges();
        }
    }
}
