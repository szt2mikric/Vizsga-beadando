using MySql.Data.MySqlClient;
using OtthonBerles.Helper;
using OtthonBerles.Models;
using System.Collections.Generic;
using System.Data;


namespace OtthonBerles.DBLayer
{
    public static class CustomersDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Customer> RetrieveAllCustomers()
        {
            string query = "SELECT * FROM otthonberlesdb.customers;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Customer> allCustomers = new List<Customer>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string fullName = dr["Customer_fullname"].ToString();
                    string email = dr["Customer_email"].ToString();
                    string password = dr["Customer_password"].ToString();
                    allCustomers.Add(new Customer(id, fullName, email, password));
                }
            }
            return allCustomers;
        }

        public static Customer RetrieveCustomerByID(int customerID)
        {
            string query = "SELECT * FROM otthonberlesdb.customers WHERE ID = (@ID) limit 1;";
            cmd = DBHelper.RunQueryWithID(query, customerID);
            Customer customer = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string fullName = dr["Customer_fullname"].ToString();
                    string email = dr["Customer_email"].ToString();
                    string password = dr["Customer_password"].ToString();
                    customer = new Customer(id, fullName, email, password);
                }
            }
            return customer;
        }

        public static bool addCustomer(string fullName, string email,string password)
        {
            //string hashedPassword = PasswordHasher.HashPassword(password);

            string query = "INSERT INTO `otthonberlesdb`.`Customers` (`Customer_fullname`, `Customer_email`, `Customer_password`)" +
                "VALUES ('" + fullName + "', '" + email + "', '" + password + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }

        public static bool RemoveCustomer(int id)
        {
            string query = "DELETE FROM otthonberlesdb.Customers WHERE ID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }
    }
}
