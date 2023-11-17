using homeWork_basic.Objects;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_basic.ISQLAdapter
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

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Get(Guid id)
        {
            try
            {
                User UserProfile = new User();

                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();
                String query = "SELECT * " +
                              "FROM Users " +
                             "WHERE id_user= @ID ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UserProfile = new User
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Name = reader["Name"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }
                return UserProfile;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
          
        }

        public int Insert(User AddData)
        {
            int i = 0;
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                String query = "INSERT into Users ( name, password)" +
                               "VALUES ( @name, @password);";
                SqlCommand command = new SqlCommand(query, connection);
              
             

                    command.Parameters.AddWithValue("@name", AddData.Name);
                    command.Parameters.AddWithValue("@password", AddData.Password);
                
                    command.ExecuteNonQuery();
          
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return i;
            }
        }

        public int Update(User UpdateData)
        {
            try
            {
                User UserProfile = new User();

                SqlConnection connection = new SqlConnection(ConnectionString);

                connection.Open();
                String query = "UPDATE Users " +
                                "SET name = @name, password = @password " +
                                 "WHERE id_user = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", UpdateData.Id);
                command.Parameters.AddWithValue("@name", UpdateData.Name);
                command.Parameters.AddWithValue("@password", UpdateData.Password);
              
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

      
    }
}
