﻿using System;
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
        public Category Category { get; set; }

        public byte CategoryId { get; set; }
    }
}