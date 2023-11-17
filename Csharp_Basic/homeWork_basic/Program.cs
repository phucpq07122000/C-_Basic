// See https://aka.ms/new-console-template for more information

/* 
 * create 4 objets :user, Product, Cart, Order - Database Shcema
 * Create SQl Adapter: AppDbAdapter - inser, update, delete, select
 * Create Cart servives: add product to user's cart
 * Create order service : create user order- add prodct from user's cart to prder: delete product in cart
 */
using homeWork_basic.bunises_logic;
using homeWork_basic.BusinessService;
using homeWork_basic.Objects;
using homeWork_basic.ISQLAdapter;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Text;
using NPOI.XWPF.UserModel;

Console.WriteLine("Hello, World!");
string ConnectString = "Data Source=LAPTOP-PDVMP1JL\\SQLEXPRESS;Initial Catalog=Basic_Csharp;Integrated Security=True";
//Console.WriteLine($"ConnectString: {ConnectString}");


ProductSqlAdapter productSqlAdapter = new ProductSqlAdapter(ConnectString);
ProductService productService = new ProductService();
CartService cartService = new CartService();
Cart cart  = new Cart();



/*List<Product> ListProduct = productSqlAdapter.GetData();

Cart shoppingCart = new Cart { id_cart = Guid.NewGuid() };

Product product1 = new Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 12.33 };
Product product2 = new Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 29.99 };



//shoppingCart.listProducts.AddRange(ListProduct);

Console.WriteLine();

shoppingCart.DisplayCart();

UserSqlAdapter userSqlAdapter = new UserSqlAdapter(ConnectString);

List<User> ListUser = userSqlAdapter.GetData();

UserService userService = new UserService();
userService.DisplayUser(ListUser);

int measurement = int.Parse(Console.ReadLine());
do
{
    
} while (measurement <= 1); */




Main();



void Main()
{
    ProductSqlAdapter productSqlAdapter = new ProductSqlAdapter(ConnectString);
    ProductService productService = new ProductService();
    CartService cartService = new CartService();
    Cart cart = new Cart();

    int mainChoice;

    do
    {
        Console.WriteLine($"Choose Process \n" +
                          $"1: User, \n " +
                          $"2: Product \n" +
                          $"3: Cart\n" +
                          $"4: Order");

        Console.Write("Enter your choice: ");
        if (!int.TryParse(Console.ReadLine(), out mainChoice))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            continue;
        }

        if (mainChoice == 1) // User
        {
            Console.WriteLine("------\n]        User    : ");
            UserSqlAdapter userSqlAdapter = new UserSqlAdapter(ConnectString);

            int userChoice;
            do
            {
                Console.WriteLine($"Choose Process \n" +
                                  $"1: Insert, \n " +
                                  $"2: Show \n" +
                                  $"3: update\n" +
                                  $"4: back");

                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out userChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                /// Insert USer
                if (userChoice == 1) 
                {
                    Console.WriteLine("------\n insert User Name và password: ");
                    User addData = new User
                    {
                        Name = Console.ReadLine(),
                        Password = Console.ReadLine(),
                    };
                    userSqlAdapter.Insert(addData);
                }
                //Get Details USer
                else if (userChoice == 2)
                {
                    Console.WriteLine("------\n Get User_Id: ");
                    String iid=Console.ReadLine();
                    userSqlAdapter.Get( Guid.Parse(iid));
                }
                //UPdate user
                /*else if (userChoice == 3)
                {
                    Console.WriteLine("------\n Get User_Id: ");
                    String iid = Console.ReadLine();
                    userSqlAdapter.Get(Guid.Parse(iid));
                }*/
                // Add more conditions for other user choices

            } while (userChoice != 4);
        }
        else if (mainChoice == 2) // Product
        {
            productSqlAdapter = new ProductSqlAdapter(ConnectString);

            List<Product> ListProduct = productSqlAdapter.GetData();
            int i = 0;
            foreach (Product product in ListProduct)
            {
                i++;
                Console.WriteLine($"\nstt: {i} , Name: {product.Name}, Price: {product.Price}");
            }

        }
        else if (mainChoice == 3) // Cart
        {
            string id;
            Console.WriteLine("list Product: \n");
            List<Product> ListProduct2 = productSqlAdapter.GetData();
            Console.WriteLine("------------------------------------------------ \n");
            productService.DisplayProduct(ListProduct2);
            do
            {

                Console.Write("\nPress Id_Product to continue Shopping, " +
                    "\nenter 1 to Pay " +
                    "\nenter 2 to delete prodcut from list " +
                    "\nor Enter 0 to stop shopping " +
                    "\n----- Enter Your Choose : "
                    );
                id = Console.ReadLine();

                if (id == "")
                {
                    Console.WriteLine(" Please enter a valid product ID.");
                }
                else if (id == "2")
                {
                    Console.Clear();
                    cart.DisplayCart();
                    Console.WriteLine("------\nchoose index of  product you want to delete ?: ");
                    int iop = int.Parse(Console.ReadLine());
                    cart.listProducts.RemoveAt(iop - 1);
                    cart.DisplayCart();
                    //  var itemToRemove = cart.listProducts.Single(r=>r.Name=="");
                }
                if (id == "1")
                {
                    Console.Clear();
                    cart.DisplayCart();
                    OrderService orderService = new OrderService();
                    orderService.payBill(cart, ConnectString);
                    //  var itemToRemove = cart.listProducts.Single(r=>r.Name=="");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------------------ \n");
                    productService.DisplayProduct(ListProduct2);
                    Product product = productSqlAdapter.Get(Guid.Parse(id));

                    cart.addProduct(product);
                    Console.Write("\n--------------Your Cart-----------------\n ");
                    cart.DisplayCart();
                }
            } while (id != "0");
            break;
        }
        // Add more conditions for other main choices

    } while (mainChoice != 4);
}







