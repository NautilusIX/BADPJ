using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BADPJ_website
{
    public class Admin
    {

        private string _adminID = null;
        private string _Username_Admin = "";
        private string _Password_Admin = "";
        private string _Phone_No_Admin = "";
        private string _Email_Admin = "";

        string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

        public Admin(string Admin_ID, string Username_Admin, string Email_Admin, string Password_Admin, string Phone_No_Admin)
        {
            _adminID = Admin_ID;
            _Username_Admin = Username_Admin;
            _Email_Admin = Email_Admin;
            _Password_Admin = Password_Admin;
            _Phone_No_Admin = Phone_No_Admin;
        }

        public Admin(string Username_Admin, string Email_Admin, string Password_Admin, string Phone_No_Admin)
        {

            _Username_Admin = Username_Admin;
            _Email_Admin = Email_Admin;
            _Password_Admin = Password_Admin;
            _Phone_No_Admin = Phone_No_Admin;
        }

        public Admin()
        {
        }
        public string Admin_ID
        {
            get { return _adminID; }
            set { _adminID = value; }
        }
        public string Username_Admin
        {
            get { return _Username_Admin; }
            set { _Username_Admin = value; }
        }

        public string Email_Admin
        {
            get { return _Email_Admin; }
            set { _Email_Admin = value; }
        }
        public string Password_Admin
        {
            get { return _Password_Admin; }
            set { _Password_Admin = value; }
        }
        public string Phone_No_Admin
        {
            get { return _Phone_No_Admin; }
            set { _Phone_No_Admin = value; }
        }


        public Admin getAdmin(string Admin_ID)
        {

            Admin adminDetail = null;

            string Username_Admin, Email_Admin, Password_Admin, Phone_No_Admin;

            string queryStr = "SELECT * FROM Admin WHERE Admin_ID = @adminID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@adminID", Admin_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Username_Admin = dr["Username_Admin"].ToString();
                Email_Admin = dr["Email_Admin"].ToString();
                Password_Admin = dr["Password_Admin"].ToString();
                Phone_No_Admin = dr["Phone_No_Admin"].ToString();

                adminDetail = new Admin(Admin_ID, Username_Admin, Email_Admin, Phone_No_Admin, Password_Admin);
            }
            else
            {
                adminDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return adminDetail;
        }

        public int AdminInsert()
        {

            int result = 0;

            string queryStr = "INSERT INTO Admin(Username_Admin, Email_Admin, Phone_No_Admin, Password_Admin) "
                            + " VALUES (@Username_Admin, @Email_Admin, @Phone_No_Admin, @Password_Admin) ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Username_Admin", this.Username_Admin);
            cmd.Parameters.AddWithValue("@Email_Admin", this.Email_Admin);
            cmd.Parameters.AddWithValue("@Password_Admin", this.Password_Admin);
            cmd.Parameters.AddWithValue("@Phone_No_Admin", this.Phone_No_Admin);

            conn.Open();
            result = cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert

        public int adminUpdate(string Username_Admin, string Phone_No_Admin)
        {
            string queryStr = "UPDATE Admin SET" +
                " Username_Admin = @Username_Admin " +
                " Phone_No_Admin = @Phone_No_Admin " +
                " WHERE Admin_ID = @Admin_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@Username_Admin", Username_Admin);
            cmd.Parameters.AddWithValue("@Phone_No_Admin", Phone_No_Admin);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update

        public int adminDelete(string adminID)
        {
            string queryStr = "DELETE FROM Admin WHERE Admin_ID = @Admin_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Admin_ID", Admin_ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;

        }//end Delete
    }
}