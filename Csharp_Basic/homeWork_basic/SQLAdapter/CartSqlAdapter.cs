using homeWork_basic.bunises_logic;
using homeWork_basic.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.ISQLAdapter
{
    internal class CartSqlAdapter : ISqlAdapter<Cart>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public CartSqlAdapter(String connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "Cart";
        }

        public Cart Get(Guid id)
        {
            try
            {

               Cart cart = new Cart();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    String query = "SELECT * " +
                                  "FROM Care " +
                                 "WHERE user_id = @ID ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                          cart = new Cart
                            {
                                user_id= Guid.Parse(reader["id_product"].ToString()),
                           
                               
                            };
                        }
                        return cart;

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Cart> GetData()
        {
            throw new NotImplementedException();
        }

        public int Insert(Cart AddData)
        {
           CartService cartService = new CartService();
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                String query = "INSERT into Cart (id_product, number, pay)" +
                               "VALUES ( @listProduct,@number, @pay);";
                SqlCommand command = new SqlCommand(query, connection);
               
            

                command.ExecuteNonQuery();

                // command.Parameters.AddWithValue("@name", AddData.);

                command.ExecuteNonQuery();

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public int Update(Cart UpdateData)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
