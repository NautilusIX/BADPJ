using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BADPJ_website
{
    public partial class UpdateUserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["Account_Type"] == null)
            //{
            //    Response.Redirect("login.aspx");
            //}
            //else
            //{

            //}

            if (Session["Account_Type"].ToString() == "User")
            {
                //string textusername = (string)Session["Username"];
                //tb_UserNameUpdate.Text = textusername;
                //string textemail = (string)Session["customer_email"];
                //tb_UserEmailUpdate.Text = textemail;
                //string textphone = (string)Session["Phone_No"];
                //tb_UserPhoneUpdate.Text = textphone;


                //string old_customer_name = (string)Session["Username"];
                //tb_UserNameUpdate.Text = old_customer_name;
                string old_customer_email = (string)Session["customer_email"];
                tb_UserEmailUpdate.Text = old_customer_email;
                //string old_customer_phone = (string)Session["Phone_No"];
                //tb_UserPhoneUpdate.Text = old_customer_phone;
            }
            else if (Session["Account_Type"].ToString() == "Coach")
            {
                //string textusername = (string)Session["Username_Coach"];
                //tb_UserNameUpdate.Text = textusername;
                //string textemail = (string)Session["coach_email"];
                //tb_UserEmailUpdate.Text = textemail;
                //string textphone = (string)Session["Phone_No_Coach"];
                //tb_UserPhoneUpdate.Text = textphone;

                string old_coach_email = (string)Session["coach_email"];
                tb_UserEmailUpdate.Text = old_coach_email;
            }
            else
            {
                //// Do something with the customerName in the session
                //string Account_Type = Session["Account_Type"].ToString();
                //// ...
                Response.Redirect("Login.aspx");
            }
        }
        

        protected void btn_ConfirmUpdateProfile_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\jason\Downloads\School\sem 2 y2\BADPJ\BADPJ website\App_Data\GetGud.mdf; Integrated Security = True");

            sql.Open();

            string username = tb_UserNameUpdate.Text;
            string email = tb_UserEmailUpdate.Text;
            string phone = tb_UserPhoneUpdate.Text;

            if (Session["Account_Type"].ToString() == "User")
            {
                
                string cmddd = 
                "UPDATE Customer SET Username = @Username, customer_email = @customer_email, Phone_No = @Phone_No WHERE Customer_ID = @Customer_ID";

               
                using (SqlCommand command = new SqlCommand(cmddd, sql))
                {

                    command.Parameters.AddWithValue("@Customer_ID", Session["Customer_ID"]);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@customer_email", email);
                    command.Parameters.AddWithValue("@Phone_No", phone);

                    command.ExecuteNonQuery();


                    Session["Username"] = username;
                    Session["customer_email"] = email;
                    Session["Phone_No"] = phone;

                    Response.Redirect("UserProfile.aspx");
                }

            }
            else if (Session["Account_Type"].ToString() == "Coach")
            {
                string cmddd =
                "UPDATE Coach SET Username_Coach = @Username_Coach, Phone_No_Coach = @Phone_No_Coach, coach_email = @coach_email WHERE Id = @Id";



                using (SqlCommand command = new SqlCommand(cmddd, sql))
                {

                    command.Parameters.AddWithValue("@Id", Session["Id"]);
                    command.Parameters.AddWithValue("@Username_Coach", username);
                    command.Parameters.AddWithValue("@coach_email", email);
                    command.Parameters.AddWithValue("@Phone_No_Coach", phone);

                    command.ExecuteNonQuery();

                    Session["Username_Coach"] = username;
                    Session["Phone_No_Coach"] = email;
                    Session["coach_email"] = phone;
                    Response.Redirect("UserProfile.aspx");

                    
                }
            }
            else
                {
                Response.Redirect("Login.aspx");
            }
            

            sql.Close();
            Response.Redirect("UserProfile.aspx");
        }

        
    }
}