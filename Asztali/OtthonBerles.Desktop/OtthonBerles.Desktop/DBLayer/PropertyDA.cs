using MySql.Data.MySqlClient;
using OtthonBerles.Helper;
using OtthonBerles.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace OtthonBerles.DBLayer
{
    public static class PropertyDA
    {
        private static MySqlCommand cmd = null;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static List<Property> RetrieveAllProperties(string searchEmail = "")
        {
            string query = "SELECT * FROM otthonberlesdb.properties";
            if (!string.IsNullOrEmpty(searchEmail))
            {
                query += $" WHERE Properties_email LIKE '%{searchEmail}%'";
            }
            query += ";";

            cmd = DBHelper.RunQueryNoParameters(query);
            List<Property> allProperties = new List<Property>();
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string propertyCity = dr["Properties_city"].ToString();
                    string propertyEmail = dr["Properties_email"].ToString();
                    string propertyType = dr["Properties_type"].ToString();
                    int propertyRoomNumber = Convert.ToInt32(dr["Properties_roomNumber"]);
                    int propertyPrice = Convert.ToInt32(dr["Properties_price"]);
                    bool propertyIsFurnished = Convert.ToBoolean(dr["Properties_isFurnished"]);
                    string propertyPossibilityOfMoving = dr["Properties_possibilityOfMoving"].ToString();
                    string propertyOthers = dr["Properties_others"].ToString();

                   
                    byte[] imageData = dr["Properties_imageData"] == DBNull.Value ? null : (byte[])dr["Properties_imageData"];

                    allProperties.Add(new Property(id, propertyCity, propertyEmail, propertyType, propertyRoomNumber, propertyPrice, propertyIsFurnished, propertyPossibilityOfMoving, propertyOthers, imageData));
                }
            }
            return allProperties;
        }


        public static Property RetrievePropertyByID(int propertyID)
        {
            string query = "SELECT * FROM otthonberlesdb.properties WHERE ID = @ID limit 1;";
            cmd = DBHelper.RunQueryWithID(query, propertyID);
            Property property = null;
            if (cmd != null)
            {
                dt = new DataTable();
                sda = new MySqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string id = dr["ID"].ToString();
                    string propertyCity = dr["Properties_city"].ToString();
                    string propertyEmail = dr["Properties_email"].ToString();
                    string propertyType = dr["Properties_type"].ToString();
                    int propertyRoomNumber = Convert.ToInt32(dr["Properties_roomNumber"]);
                    int propertyPrice = Convert.ToInt32(dr["Properties_price"]);
                    bool propertyIsFurnished = Convert.ToBoolean(dr["Properties_isFurnished"]);
                    string propertyPossibilityOfMoving = dr["Properties_possibilityOfMoving"].ToString();
                    string propertyOthers = dr["Properties_others"].ToString();
                    byte[] imageData = (byte[])dr["Properties_imageData"];
                    property = new Property(id, propertyCity, propertyEmail, propertyType, propertyRoomNumber, propertyPrice, propertyIsFurnished, propertyPossibilityOfMoving, propertyOthers, imageData);
                    break; 
                }
            }
            return property;
        }

        public static bool AddProperty(string propertyCity, string propertyEmail, string propertyType, int propertyRoomNumber, int propertyPrice, bool propertyIsFurnished, string propertyPossibilityOfMoving, string propertyOthers, byte[] imageData)
        {

            string imageDataString = Convert.ToBase64String(imageData);

            string query = $"INSERT INTO `otthonberlesdb`.`properties` (`Properties_city`, `Properties_email`, `Properties_type`, `Properties_roomNumber`, `Properties_price`, `Properties_isFurnished`, `Properties_possibilityOfMoving`, `Properties_others`, `Properties_imageData`)" +
                $"VALUES ('{propertyCity}', '{propertyEmail}', '{propertyType}', {propertyRoomNumber}, {propertyPrice}, {Convert.ToInt32(propertyIsFurnished)}, '{propertyPossibilityOfMoving}', '{propertyOthers}', '{imageDataString}');";

            MySqlCommand cmd = DBHelper.RunQueryNoParameters(query);
            return cmd != null;
        }


        public static bool RemoveProperty(int id)
        {
            string query = "DELETE FROM otthonberlesdb.properties WHERE ID = @ID";
            cmd = DBHelper.RunQueryWithID(query, id);
            return cmd != null;
        }

        public static bool UpdateProperty(int id, string city, string email, string type, int roomNumber, int price, bool isFurnished, string possibilityOfMoving, string others, byte[] imageData)
        {
            string query = "UPDATE otthonberlesdb.properties SET Properties_city = @City, Properties_email = @Email, Properties_type = @Type, Properties_roomNumber = @RoomNumber, Properties_price = @Price, Properties_isFurnished = @IsFurnished, Properties_possibilityOfMoving = @PossibilityOfMoving, Properties_others = @Others, Properties_imageData = @ImageData WHERE Id = @Id";


            MySqlCommand cmd = DBHelper.RunQueryWithParamList(query, new Dictionary<string, object>
            {
                { "@City", city },
                { "@Email", email },
                { "@Type", type },
                { "@RoomNumber", roomNumber },
                { "@Price", price },
                { "@IsFurnished", isFurnished },
                { "@PossibilityOfMoving", possibilityOfMoving },
                { "@Others", others },
                { "@ImageData", imageData },
                { "@ID", id.ToString() }
            });


            return cmd != null;
        }
    }
}
