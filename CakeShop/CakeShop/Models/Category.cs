using System.Collections.Generic;

namespace CakeShop.Models
{
    public class Category
    {
        public int Id { get; set; }

 
        public string Nume { get; set; }

    
        public virtual List<Cake> Cakes { get; set; }
    }
}