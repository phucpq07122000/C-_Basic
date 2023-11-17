using homeWork_basic.Objects;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.bunises_logic
{
    public class CartService
    {
        
        public String parseListProductToString(List<Product> listProduct)
        {
            String resultString = string.Join("#", listProduct.Select(product => $"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}"));
            return resultString;
        }

       /* public List<Product> ParseStringToListProduct(String stringList)
        {
            List<String> result = stringList.Split('#').ToList();
            string json = "{\"Id\": 1, \"Name\": \"Abdullah\"}";

            User user = JsonConvert.DeserializeObject<User>(json);
            return null;
        }*/



    }
}
