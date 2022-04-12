using System;
using System.Data.SqlClient;
using TicketManagementSystem.Interfaces;

namespace TicketManagementSystem
{
    public class UserRepository : IDisposable, IUserRepository
    {
        public User GetUser(string username)
        {
            try
            {
                var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["database"].ConnectionString;

                string sql = "SELECT TOP 1 FROM Users u WHERE u.Username == @p1";
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var command = new SqlCommand(sql, connection)
                    {
                        CommandType = System.Data.CommandType.Text,
                    };

                    command.Parameters.Add("@p1", System.Data.SqlDbType.NVarChar).Value = username;

                    return (User)command.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetAccountManager()
        {
            return GetUser("Sarah");
        }

        public void Dispose()
        {
            // Free up resources
        }
    }
}
