using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.Objects
{
    public class Cart
    {
        public Guid user_id { get; set; }
        public List<Product> listProducts { get; set; }= new List<Product>();  
 


        public void addProduct(Product product)
        {
            listProducts.Add(product);
        }

        public void DisplayCart()
        {
            // Console.WriteLine($"Cart ID: {id_cart}");

            int i = 0;
            foreach (Product product in listProducts)
            {
                i++;
               
                Console.WriteLine($"     Stt: {i} , Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                
            }

            Console.WriteLine($"Total number of products in the cart: {listProducts.Count}");
            Console.WriteLine($"Total payment in the cart: {listProducts.Sum(product => product.Price)}");
        }
        public String parseListProductToString(List<Product> listProduct){
            string combinedString = string.Join(",", listProduct);
            return combinedString;
             
        }


    }
}

 