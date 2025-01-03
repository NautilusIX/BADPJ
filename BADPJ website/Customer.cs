using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BADPJ_website
{
    public class Customer
    {
        private string _custID = null;
        private string _Username = "";
        private string _Password = "";
        private string _Phone_No = "";
        private string _Email = "";

        string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

        public Customer(string Customer_ID, string Username, string customer_email, string Password, string Phone_No)
        {
            _custID = Customer_ID;
            _Username = Username;
            _Email = customer_email;
            _Password = Password;
            _Phone_No = Phone_No;
        }

        public Customer(string Username, string customer_email, string Password, string Phone_No)
        {

            _Username = Username;
            _Email = customer_email;
            _Password = Password;
            _Phone_No = Phone_No;
        }

        public Customer()
        {
        }
        public string Customer_ID
        {
            get { return _custID; }
            set { _custID = value; }
        }
        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string customer_email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public string Phone_No
        {
            get { return _Phone_No; }
            set { _Phone_No = value; }
        }

        public Customer CustomerLogin(string customer_email)
        {
            Customer custDetail1 = null;

            string Username, customer_Email, Password, Phone_No;

            string queryStr = "SELECT * FROM Customer WHERE customer_email = @customer_email";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Username = dr["Username"].ToString();
                customer_Email = dr["customer_Email"].ToString();
                Password = dr["Password"].ToString();
                Phone_No = dr["Phone_No"].ToString();

                custDetail1 = new Customer(Username, customer_Email, Password, Phone_No);
            }
            else
            {
                custDetail1 = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return custDetail1;
        }

        public Customer getCustomer(string Customer_ID)
        {

            Customer custDetail = null;

            string Username, customer_Email, Password, Phone_No;

            string queryStr = "SELECT * FROM Customer WHERE Customer_ID = @Customer_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Customer_ID", Customer_ID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Username = dr["Username"].ToString();
                customer_Email = dr["customer_Email"].ToString();
                Password = dr["Password"].ToString();
                Phone_No = dr["Phone_No"].ToString();

                custDetail = new Customer(Customer_ID, Username, customer_Email, Password, Phone_No);
            }
            else
            {
                custDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return custDetail;
        }

        public List<Customer> getCustomerAll()
        {
            List<Customer> custList = new List<Customer>();

            string Customer_ID, Username, customer_email, Password, Phone_No;

            string queryStr = "SELECT * FROM Customer Order By Customer_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Customer_ID = dr["Customer_ID"].ToString();
                Username = dr["Username"].ToString();
                customer_email = dr["customer_email"].ToString();
                Password = dr["Password"].ToString();
                Phone_No = dr["Phone_No"].ToString();
                Customer a = new Customer(Customer_ID, Username, customer_email, Password, Phone_No);
                custList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return custList;
        }

        public int CustomerInsert()
        {

            int result = 0;

            string queryStr = "INSERT INTO Customer(Username, customer_email, Phone_No, Password) "
                            + " VALUES (@Username, @customer_email, @Phone_No, @Password) ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Username", this.Username);
            cmd.Parameters.AddWithValue("@customer_email", this.customer_email);
            cmd.Parameters.AddWithValue("@Password", this.Password);
            cmd.Parameters.AddWithValue("@Phone_No", this.Phone_No);

            conn.Open();
            result = cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert

        public int customerUpdate(string Customer_ID, string Username, string Password, string Phone_No)
        {
            string queryStr = "UPDATE Customer SET" + " Username = @Username, " + "Password = @Password, " + "Phone_No = @Phone_No " + "WHERE Customer_ID = @Customer_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Phone_No", Phone_No);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update

        public int customerDelete(string Customer_ID)
        {
            string queryStr = "DELETE FROM Customer WHERE Customer_ID = @Customer_ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Customer_ID", Customer_ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;

        }//end Delete

        public int customerPaymentDelete(string customer_email)
        {
            string queryStr = "DELETE FROM Payment WHERE customer_email = @customer_email";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return nofRow;

        }//end Delete
    }
}