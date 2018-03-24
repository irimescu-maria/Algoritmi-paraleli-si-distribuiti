using System.Collections.Generic;

namespace CakeShop.Models
{
    public class Category
    {
        public byte Id { get; set; }

 
        public string Nume { get; set; }

    
        public List<Cake> Cakes { get; set; }
    }
}