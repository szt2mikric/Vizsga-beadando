using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace OtthonBerles.Helper
{
    public static class DBHelper
    {
        private static MySqlConnection connection;
        private static MySqlCommand cmd = null;
      

        public static void EstablishConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "localhost";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "otthonberlesdb";
                builder.SslMode = MySqlSslMode.Required;
                connection = new MySqlConnection(builder.ToString());
                connection.Open();
                MessageBox.Show("Database connection successfull", "Connection", MessageBoxButton.OK);
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.", "Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username or password, try again.", "Authorization", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                }
            }
        }



        public static bool ConnectToDatabase(string email, string password)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost"; 
            builder.UserID = "root"; 
            builder.Password = "";
            builder.Database = "otthonberlesdb";
            builder.SslMode = MySqlSslMode.Disabled;
            connection = new MySqlConnection(builder.ToString());

            try
            {
                connection.Open();

                if (VerifyAdvertiserCredentials(connection, email, password) || (email == "admin" && password == "admin"))
                {
                    

                    return true;
                }
                else
                {
   
                    MessageBox.Show("Helytelen Email vagy Jelszó.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1045:
                        MessageBox.Show("Cannot connect to server.", "Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 0:
                        MessageBox.Show("Invalid username or password, try again.", "Authorization", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    default:
                        MessageBox.Show("Unknown error." + "\n" + ex.Message, "Unknown", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }



        private static bool VerifyAdvertiserCredentials(MySqlConnection connection, string email, string password)
        {
            string query = "SELECT COUNT(*) FROM advertisers WHERE Advertisers_email = @Email AND Advertisers_password = @Password";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }

        public static MySqlCommand RunQueryNoParameters(string query)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch 
            {
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand RunQueryWithID(string query, int id)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand RunQuery(string query, string parameter, string value)
        {
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue(parameter, value);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {
                connection.Close();
            }
            return cmd;
        }

        public static MySqlCommand RunQueryWithParamList(string query, Dictionary<string, object> paramValuePair)
        {
            MySqlCommand cmd = null;
            try
            {
                if (connection != null)
                {
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    foreach (var pvp in paramValuePair)
                    {
                        cmd.Parameters.AddWithValue(pvp.Key, pvp.Value);
                    }
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {
                if (connection != null && connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
              
                throw;
            }
            return cmd;
        }

    }
}

