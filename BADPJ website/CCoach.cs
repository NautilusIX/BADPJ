using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BADPJ_website
{
    public class CCoach
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string pass { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

        public int CoachInsert()
        {

            // string msg = null;
            int result = 0;

            SqlConnection conn1 = new SqlConnection(_connStr);
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand("Select isnull(max(Id),0)+1 from  Coach", conn1);
            int id = Convert.ToInt32(cmd1.ExecuteScalar());
            conn1.Close();
            string queryStr = "INSERT INTO Coach(Id, Username_Coach, Password_Coach, Phone_No_Coach, coach_email)"
                + " values (" + id + ", '" + name + "', '" + pass + "', '" + phone + "', '" + email + "')";
            //+ "values (@Listing_ID,@Email_Coach, @Coach_Desc, @Coach_Image, @Coach_Price,@Coach_Name)";


            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                conn.Open();
                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                conn.Close();
            }

            catch (Exception ex)
            {

                result = 0;
                // can write additonal error message by having a parameter called exception then do ex.m

            }
            return result;



        }
    }
}