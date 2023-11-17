using homeWork_basic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.BusinessService
{
    public class ProductService
    {

        public void DisplayProduct(List<Product> listProduct)
        {
          
            foreach (Product product in listProduct)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");       
            }
            
        }
    }
}
