using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CakeShop.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int CakeId { get; set; }
        public int Cantitate { get; set; }
        public virtual Cake Cake { get; set; }
    }
}