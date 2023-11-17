using homeWork_basic.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.ISQLAdapter
{
    public class ProductSqlAdapter : ISqlAdapter<Product>
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public ProductSqlAdapter(String connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "Product";
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Product follow id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(Guid id)
        {
            try
            {
                
                Product product = new Product();
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    String query = "SELECT id_product, name_product, price " +
                                  "FROM Product " +
                                 "WHERE id_product= @ID ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = Guid.Parse(reader["id_product"].ToString()),
                                Name = reader["name_product"].ToString(),
                                Price = double.Parse(reader["price"].ToString()),
                            };
                        }
                        return product;

                    }

                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Product> GetData()
        
        {
            try
            {
                List<Product> productList = new List<Product>();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM Product";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    Id = Guid.Parse(reader["id_product"].ToString()),
                                    Name = reader["name_product"].ToString(),
                                    Price = float.Parse(reader["price"].ToString()),
                                };

                                productList.Add(product);
                            }
                        }
                    }
                }
                return productList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public int Insert(Product AddData)
        {
            throw new NotImplementedException();
        }

        public int Update(Product UpdateData)
        {
            throw new NotImplementedException();
        }
    }
}
