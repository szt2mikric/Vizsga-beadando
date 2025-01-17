using MySql.Data.MySqlClient;
using OtthonBerles.Helper;
using OtthonBerles.Models;
using System.Collections.Generic;
using System.Data;


namespace OtthonBerles.DBLayer
{
    public static class AdvertisersDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Advertiser> RetrieveAllAdvertisers()
        {
            string query = "SELECT * FROM otthonberlesdb.advertisers;";
            cmd = DBHelper.RunQueryNoParameters(query);
            List<Advertiser> allAdvertisers = new List<Advertiser>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string advertiserFullName = dr["Advertisers_fullname"].ToString();
                    string advertiserEmail = dr["Advertisers_email"].ToString();
                    string advertiserPassword = dr["Advertisers_password"].ToString();
                    string advertiserCompanyName = dr["Advertisers_companyname"].ToString();
                    allAdvertisers.Add(new Advertiser(id, advertiserFullName, advertiserEmail, advertiserPassword, advertiserCompanyName));
                }
            }
            return allAdvertisers;
        }
        

        public static Advertiser RetrieveAdvertiserByID(int advertiserID)
        {
            string query = "SELECT * FROM otthonberlesdb.advertisers WHERE ID = (@ID) limit 1;";
            cmd = DBHelper.RunQueryWithID(query, advertiserID);
            Advertiser advertiser = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string advertiserFullName = dr["Advertisers_fullname"].ToString();
                    string advertiserEmail = dr["Advertisers_email"].ToString();
                    string advertiserPassword = dr["Advertisers_password"].ToString();
                    string advertiserCompanyName = dr["Advertisers_companyname"].ToString();
                    advertiser = new Advertiser(id, advertiserFullName, advertiserEmail, advertiserPassword, advertiserCompanyName);
                }
            }
            return advertiser;
        }

        public static bool AddAdvertiser(string advertiserFullName, string advertiserEmail, string advertiserPassword, string advertiserCompanyName)
        {
            //string hashedPassword = PasswordHasher.HashPassword(advertiserPassword);

           
            string query = "INSERT INTO `otthonberlesdb`.`advertisers` (`Advertisers_fullname`, `Advertisers_email`, `Advertisers_password`, `Advertisers_companyname`)" +
                "VALUES ('" + advertiserFullName + "', '" + advertiserEmail + "', '" + advertiserPassword + "', '" + advertiserCompanyName + "');";
            cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }
        public static bool RemoveAdvertiser(int id)
        {
            string query = "DELETE FROM otthonberlesdb.advertisers WHERE ID = (@ID)";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }

        public static bool UpdateAdvertiser(int id, string advertiserFullName, string advertiserEmail, string advertiserPassword, string advertiserCompanyName)
        {
            string query = "UPDATE otthonberlesdb.advertisers SET Advertisers_fullname = @FullName, Advertisers_email = @Email, Advertisers_password = @Password, Advertisers_companyname = @CompanyName WHERE ID = @ID";

            MySqlCommand cmd = DBHelper.RunQueryWithParamList(query, new Dictionary<string, object>
{
                { "@FullName", advertiserFullName },
                { "@Email", advertiserEmail },
                { "@Password", advertiserPassword },
                { "@CompanyName", advertiserCompanyName },
                { "@ID", id } 
            });


            return cmd != null;
        }
    }
}
