using CakeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CakeShop.Controllers.Api
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/categories
        public IEnumerable<Cart> GetCategories()
        {
            return _context.Categories.ToList();
        }

        //GET /api/categories/1
        public Cart GetCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);

            if (category == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return category;
        }

        //POST /api/categories
        [HttpPost]
        public Cart CreateCategory(Cart category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        //PUT /api/categories/1
        [HttpPut]
        public void UpdateCategory(int id,Cart category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var categoryInDb = _context.Categories.SingleOrDefault(c => c.Id == category.Id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            categoryInDb.Nume = category.Nume;


            _context.SaveChanges();
        }

        //DELETE /api/categories/1
        [HttpDelete]
        public void DeleteCategory(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(c=>c.Id == id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
        }
    }
}
