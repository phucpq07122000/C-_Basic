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
    public class OrderSqlAdapter : ISqlAdapter<Order>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

     
        public OrderSqlAdapter(String connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "Orders";
        }

        public Order Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetData()
        {
            throw new NotImplementedException();
        }

        public int Insert(Order AddData)
        {
            int i = 0;
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                String query = "INSERT into Orders ( list_product, number ,total)" +
                               "VALUES ( @list_product, @number, @total);";
                SqlCommand command = new SqlCommand(query, connection);

 
                command.Parameters.AddWithValue("@list_product", AddData.listProduct);
                command.Parameters.AddWithValue("@number", AddData.number);
                command.Parameters.AddWithValue("@total", AddData.payment);

                command.ExecuteNonQuery();

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return i;
            }
        }

        public int Update(Order UpdateData)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
