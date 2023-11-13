using homeWork_basic.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.SQLAdapter
{
    public class UserSqlAdapter : ISqlAdapter<User>
    {


        public string ConnectionString { get; set; }
        public string TableName { get; set; }

        public UserSqlAdapter(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.TableName = "Users";
        }

        /// <summary>
        /// Get all Data from dbo_Users
        /// </summary>
        /// <returns></returns>
        public List<User> GetData()
        {
            try
            {
                List<User> userList = new List<User>();

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = $"SELECT * FROM Users";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    Id = Guid.Parse(reader["id_user"].ToString()),
                                    Name = reader["name"].ToString(),
                                    Password = reader["password"].ToString()
                                };

                                userList.Add(user);
                            }
                        }
                    }
                }
                return userList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Insert(User AddData)
        {
            throw new NotImplementedException();
        }

        public int Update(User UpdateData)
        {
            throw new NotImplementedException();
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
