using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.Objects
{
    public class Cart
    {
        public Guid id_cart { get; set; }
        List<Product> list_products { get; set; }= new List<Product>();  
        public int number { get; set; }
        public int payment { get; set; }
    }
}

