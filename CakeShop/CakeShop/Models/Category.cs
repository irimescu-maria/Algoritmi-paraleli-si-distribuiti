using System.Collections.Generic;

namespace CakeShop.Models
{
    public class Cart
    {
        public int Id { get; set; }

 
        public string Nume { get; set; }

    
        public virtual List<Cake> Cakes { get; set; }
    }
}