using homeWork_basic.bunises_logic;
using homeWork_basic.ISQLAdapter;
using homeWork_basic.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.BusinessService
{
    public class OrderService
    {
       
      public void payBill(Cart cart, String ConnectString)
        {
            CartService cartService = new CartService();
            Order order = new Order
            {
                listProduct = cartService.parseListProductToString(cart.listProducts),
                number=cart.listProducts.Count,
                payment= cart.listProducts.Sum(product => product.Price)

            };
            OrderSqlAdapter orderSqlAdapter = new OrderSqlAdapter(ConnectString);
            orderSqlAdapter.Insert(order);

           Console.WriteLine($"{order.payment}");   
        }
    }
}
