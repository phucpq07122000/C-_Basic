using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.Objects
{
    public class Order
    {
        public Guid Id_Oder { get; set; }

        public String? listProduct {  get; set; }
        public int number { get; set; }
        public double payment { get; set; }
    }
}
