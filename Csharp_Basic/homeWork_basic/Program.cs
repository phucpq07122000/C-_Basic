// See https://aka.ms/new-console-template for more information

/* 
 * create 4 objets :user, Product, Cart, Order - Database Shcema
 * Create SQl Adapter: AppDbAdapter - inser, update, delete, select
 * Create Cart servives: add product to user's cart
 * Create order service : create user order- add prodct from user's cart to prder: delete product in cart
 */
using homeWork_basic.Objects;
using homeWork_basic.SQLAdapter;

Console.WriteLine("Hello, World!");
string ConnectString = "Data Source=LAPTOP-PDVMP1JL\\SQLEXPRESS;Initial Catalog=Basic_Csharp;Integrated Security=True";
Console.WriteLine($"ConnectString: {ConnectString}");

UserSqlAdapter userSqlAdapter = new UserSqlAdapter(ConnectString);
//userSqlAdapter.GetData();
//Console.WriteLine(userSqlAdapter.GetData());

List<User> ListUser = userSqlAdapter.GetData();
foreach (User user in ListUser)
{
    Console.WriteLine($"id: {user.Id} , Name: {user.Name}, Price: {user.Password}");
}

String[] Chosse = { "User", "Product", "Cart", "Order" };

Console.WriteLine($" Enter according to the instructions \n"+ 
                   "1 -> for Interaction OBject User"     );
int i = int.Parse(Console.ReadLine());
switch (i)
{
    case 6:
        Console.WriteLine("Today is Saturday.");

        break;
    case 7:
        Console.WriteLine("Today is Sunday.");
        break;
    default:
        Console.WriteLine("Looking forward to the Weekend.");
        break;
}


