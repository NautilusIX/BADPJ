using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

using System.Net;
using System.Net.Mail;

namespace BADPJ_website
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        String randomCode;
        public static String to;

        protected void Btn_NewPassword_Click(object sender, EventArgs e)
        {
            string email = Tb_ForgotEmail.Text;

            if (Tb_OTPForgot.Text == "")
            {
                lbl_ErrorMessage1.Text = "Verify OTP";
            }
            else if (Session["Code"].ToString() == (Tb_OTPForgot.Text).ToString())
            {
                to = Tb_ForgotEmail.Text;
                lbl_ErrorMessage1.Text = "OTP Correct";

                // Check if the user is in the customer database
                if (IsUserInCustomerDatabase(email))
                {

                    //Session["Account_Type"] = "User";
                    //Session["Customer_ID"] = Customer_ID;
                    //Session["Username"] = Username;
                    //Session["customer_email"] = customer_email;
                    //Session["Password"] = Password;
                    //Session["Phone_No"] = Phone_No;
                    //Response.Redirect("index.aspx");

                    string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(_connStr))
                    {
                        conn.Open();
                        string query = "SELECT Customer_ID, Username, customer_email, Password, Phone_No FROM Customer WHERE customer_email = @customer_email";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@customer_email", email);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {



                                    int Customer_ID = reader.GetInt32(0);
                                    string Username = reader.GetString(1);
                                    string customer_email = reader.GetString(2);
                                    string Password = reader.GetString(3);
                                    string Phone_No = reader.GetString(4);



                                }
                                else
                                {
                                    lbl_ErrorMessage1.Text = "update not working";
                                }
                            }
                        }

                        string updateQuery = "UPDATE Customer SET Password = @Password WHERE customer_email = @customer_email";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Password", Tb_ForgotPassword.Text);
                            cmd.Parameters.AddWithValue("@customer_email", email);

                            cmd.ExecuteNonQuery();

                            Response.Redirect("login.aspx");
                        }
                        conn.Close();


                    }


                }
                // Check if the user is in the coach database
                else if (IsUserInCoachDatabase(email))
                {
                    string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(_connStr))
                    {
                        conn.Open();
                        string query = "SELECT Id, Username_Coach, coach_email, Password_Coach, Phone_No_Coach FROM Coach WHERE coach_email = @coach_email";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@coach_email", email);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string Id = reader.GetString(0);
                                    string Username_Coach = reader.GetString(1);
                                    string Password_Coach = reader.GetString(2);
                                    string Phone_No_Coach = reader.GetString(3);
                                    string coach_email = reader.GetString(4);
                                }
                                else
                                {
                                    lbl_ErrorMessage1.Text = "update not working";
                                }
                            }
                        }

                        string updateQuery = "UPDATE Coach SET Password_Coach = @Password_Coach WHERE coach_email = @coach_email";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Password_Coach", Tb_ForgotPassword.Text);
                            cmd.Parameters.AddWithValue("@coach_email", email);
                            cmd.ExecuteNonQuery();

                            Response.Redirect("login.aspx");
                        }
                        conn.Close();
                    }
                }
                // Check if the user is in the admin database
                else if (IsUserInAdminDatabase(email))
                {
                    string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

                    using (SqlConnection conn = new SqlConnection(_connStr))
                    {
                        conn.Open();
                        string query = "SELECT Admin_ID, Username_Admin, Email_Admin, Password_Admin, Phone_No_Admin FROM Admin WHERE Email_Admin = @Email_Admin";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email_Admin", email);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {



                                    int Customer_ID = reader.GetInt32(0);
                                    string Username = reader.GetString(1);
                                    string customer_email = reader.GetString(2);
                                    string Password = reader.GetString(3);
                                    string Phone_No = reader.GetString(4);



                                }
                                else
                                {
                                    lbl_ErrorMessage1.Text = "update not working";
                                }
                            }
                        }

                        string updateQuery = "UPDATE Admin SET Password_Admin = @Password_Admin WHERE Email_Admin = @Email_Admin";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Password_Admin", Tb_ForgotPassword.Text);
                            cmd.Parameters.AddWithValue("@Email_Admin", email);

                            cmd.ExecuteNonQuery();

                            Response.Redirect("login.aspx");
                        }
                        conn.Close();


                    }

                }
                else
                {
                    lbl_ErrorMessage1.Text = "Incorrect email";

                }

            }
        }

            private bool IsUserInCustomerDatabase(string customer_email)
        {
            // Code to check if the user is in the customer database
            // Return true if the user is found, false otherwise

            // Connect to the database
            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                // Check if the user is in the customer database
                string query = "SELECT * FROM Customer WHERE customer_email = @customer_email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customer_email", customer_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // User found in the database
                            return true;
                        }
                        else
                        {
                            // User not found in the database
                            return false;
                        }
                    }
                }
            }
        }

        private bool IsUserInCoachDatabase(string coach_email)
        {
            // Code to check if the user is in the coach database
            // Return true if the user is found, false otherwise

            // Connect to the database
            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                // Check if the user is in the customer database
                string query = "SELECT * FROM Coach WHERE coach_email = @coach_email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@coach_email", coach_email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // User found in the database
                            return true;
                        }
                        else
                        {
                            // User not found in the database
                            return false;
                        }
                    }
                }
            }
        }

        private bool IsUserInAdminDatabase(string Email_Admin)
        {
            // Code to check if the user is in the admin database
            // Return true if the user is found, false otherwise

            // Connect to the database
            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                // Check if the user is in the customer database
                string query = "SELECT * FROM Admin WHERE Email_Admin = @Email_Admin";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email_Admin", Email_Admin);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // User found in the database
                            return true;
                        }
                        else
                        {
                            // User not found in the database
                            return false;
                        }
                    }
                }
            }
        }

        protected void Btn_GetOTPForgot_Click(object sender, EventArgs e)
        {
            String from, pass, messageBody;
            Random rand = new Random();

            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Tb_ForgotEmail.Text).ToString();
            from = "getgudwithus@gmail.com"; // own email
            pass = "xxguqcnvjdcfqaco";
            messageBody = "Your OTP is : " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Email Confirmation Code";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                lbl_ErrorMessage1.Text = "OTP Sent Successfully";
                Session["Code"] = randomCode;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                lbl_ErrorMessage1.Text = "OTP NOT Sent Successfully";
            }
        }
    }
}