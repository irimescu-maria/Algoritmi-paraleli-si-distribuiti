using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CakeShop.Models
{
    public class Cake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public string ImagePath { get; set; }

        //Navigation properties
        public Cart Category { get; set; }

        public int CategoryId { get; set; }
    }
}