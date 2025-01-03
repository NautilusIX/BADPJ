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

namespace BADPJ_website
{



    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["customer_email"] != null && Request.Cookies["Password"] != null)
                {
                    Tb_LoginEmail.Text = Request.Cookies["customer_email"].Value;
                    Tb_LoginPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
                else if(Request.Cookies["coach_email"] != null && Request.Cookies["Password_Coach"] != null)
                {
                    Tb_LoginEmail.Text = Request.Cookies["coach_email"].Value;
                    Tb_LoginPassword.Attributes["value"] = Request.Cookies["Password_Coach"].Value;
                }
            }
            
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            

            if (captchaCode.Text.ToLower() == Session["sessionCaptcha"].ToString())
            {
            
                string email = Tb_LoginEmail.Text;
                string password = Tb_LoginPassword.Text;

                

                // Check if the user is in the customer database
                if (IsUserInCustomerDatabase(email, password))
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
                        string query = "SELECT Customer_ID, Username, customer_email, Password, Phone_No FROM Customer WHERE customer_email = @customer_email AND Password = @Password";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@customer_email", email);
                            cmd.Parameters.AddWithValue("@password", password);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {

                                    // new codes for remember me
                                    if (CheckBox1.Checked){
                                        Response.Cookies["customer_email"].Value = Tb_LoginEmail.Text;
                                        Response.Cookies["Password"].Value = Tb_LoginPassword.Text;
                                        Response.Cookies["customer_email"].Expires = DateTime.Now.AddMinutes(1);
                                        Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(1);
                                    }
                                    else
                                    {
                                        Response.Cookies["customer_email"].Expires = DateTime.Now.AddMinutes(-1);
                                        Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(-1);
                                    }
                                    // new codes

                                    int Customer_ID = reader.GetInt32(0);
                                    string Username = reader.GetString(1);
                                    string customer_email = reader.GetString(2);
                                    string Password = reader.GetString(3);
                                    string Phone_No = reader.GetString(4);

                                    Session["Account_Type"] = "User";
                                    Session["Customer_ID"] = Customer_ID;
                                    Session["Username"] = Username;
                                    Session["customer_email"] = customer_email;
                                    Session["Password"] = Password;
                                    Session["Phone_No"] = Phone_No;


                                    Response.Redirect("index.aspx");
                                }
                                else
                                {
                                    lbl_ErrorMessage.Text = "Session not working";
                                }
                            }
                        }
                        conn.Close();
                    }

                }
                // Check if the user is in the coach database
                else if (IsUserInCoachDatabase(email, password))
                {
                    //Session["Account_Type"] = "Coach";
                    //Response.Redirect("Coach_Listing.aspx");

                    string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(_connStr))
                    {
                        conn.Open();
                        string query = "SELECT Id, Username_Coach, Password_Coach, Phone_No_Coach, coach_email FROM Coach WHERE coach_email = @coach_email AND Password_Coach = @Password_Coach";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@coach_email", email);
                            cmd.Parameters.AddWithValue("@Password_Coach", password);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // new codes for remember me
                                    if (CheckBox1.Checked)
                                    {
                                        Response.Cookies["coach_email"].Value = Tb_LoginEmail.Text;
                                        Response.Cookies["Password_Coach"].Value = Tb_LoginPassword.Text;
                                        Response.Cookies["coach_email"].Expires = DateTime.Now.AddMinutes(1);
                                        Response.Cookies["Password_Coach"].Expires = DateTime.Now.AddMinutes(1);
                                    }
                                    else
                                    {
                                        Response.Cookies["coach_email"].Expires = DateTime.Now.AddMinutes(-1);
                                        Response.Cookies["Password_Coach"].Expires = DateTime.Now.AddMinutes(-1);
                                    }
                                    // new codes

                                    string Id = reader.GetString(0);
                                    string Username_Coach = reader.GetString(1);
                                    string Password_Coach = reader.GetString(2);
                                    string Phone_No_Coach = reader.GetString(3);
                                    string coach_email = reader.GetString(4);

                                    Session["Account_Type"] = "Coach";
                                    Session["Id"] = Id;
                                    Session["Username_Coach"] = Username_Coach;
                                    Session["Password_Coach"] = Password_Coach;
                                    Session["Phone_No_Coach"] = Phone_No_Coach;
                                    Session["coach_email"] = coach_email;
                                    Response.Redirect("COACH_OWN_LISTING.aspx");
                                }
                                else
                                {
                                    lbl_ErrorMessage.Text = "Session not working";
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                // Check if the user is in the admin database
                else if (IsUserInAdminDatabase(email, password))
                {
                    //Session["Account_Type"] = "Admin";
                    //Response.Redirect("admin.aspx");

                    string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(_connStr))
                    {
                        conn.Open();
                        string query = "SELECT Admin_ID, Username_Admin, Email_Admin, Password_Admin, Phone_No_Admin FROM Admin WHERE Email_Admin = @Email_Admin AND Password_Admin = @Password_Admin";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email_Admin", email);
                            cmd.Parameters.AddWithValue("@Password_Admin", password);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int Admin_ID = reader.GetInt32(0);
                                    string Username_Admin = reader.GetString(1);
                                    string Email_Admin = reader.GetString(2);
                                    string Password_Admin = reader.GetString(3);
                                    string Phone_No_Admin = reader.GetString(4);

                                    Session["Account_Type"] = "Admin";
                                    Session["Admin_ID"] = Admin_ID;
                                    Session["Username_Admin"] = Username_Admin;
                                    Session["Email_Admin"] = Email_Admin;
                                    Session["Password_Admin"] = Password_Admin;
                                    Session["Phone_No_Admin"] = Phone_No_Admin;
                                    Response.Redirect("admin.aspx");
                                }
                                else
                                {
                                    lbl_ErrorMessage.Text = "Session not working";                                
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                else
                {
                    lbl_ErrorMessage.Text = "Incorrect email or password";
                    
                }

            }
            else
            {
                lbl_ErrorMessage.Text = "Captcha invalid";
            }

            

            }

        private bool IsUserInCustomerDatabase(string customer_email, string password)
        {
            // Code to check if the user is in the customer database
            // Return true if the user is found, false otherwise

            // Connect to the database
            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                // Check if the user is in the customer database
                string query = "SELECT * FROM Customer WHERE customer_email = @customer_email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customer_email", customer_email);
                    command.Parameters.AddWithValue("@Password", password);

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

        private bool IsUserInCoachDatabase(string coach_email, string Password_Coach)
        {
            // Code to check if the user is in the coach database
            // Return true if the user is found, false otherwise

            // Connect to the database
            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                // Check if the user is in the customer database
                string query = "SELECT * FROM Coach WHERE coach_email = @coach_email AND Password_Coach = @Password_Coach";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@coach_email", coach_email);
                    command.Parameters.AddWithValue("@Password_Coach", Password_Coach);

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

        private bool IsUserInAdminDatabase(string Email_Admin, string Password_Admin)
        {
            // Code to check if the user is in the admin database
            // Return true if the user is found, false otherwise

            // Connect to the database
            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                // Check if the user is in the customer database
                string query = "SELECT * FROM Admin WHERE Email_Admin = @Email_Admin AND Password_Admin = @Password_Admin";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email_Admin", Email_Admin);
                    command.Parameters.AddWithValue("@Password_Admin", Password_Admin);

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

    }
}