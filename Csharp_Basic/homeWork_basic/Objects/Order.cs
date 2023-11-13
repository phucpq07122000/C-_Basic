using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.Objects
{
    public class Order
    {
        public Guid Id_User { get; set; } 

        List<Cart> ListCarts { get; set; } = new List<Cart>();    

        public int Total { get; set; }  
    }
}
