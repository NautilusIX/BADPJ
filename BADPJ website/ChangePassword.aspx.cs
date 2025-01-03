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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account_Type"] == null)
            {
                
                Response.Redirect("Login.aspx");
            }
            else
            {
                //// Do something with the customerName in the session
                //string Account_Type = Session["Account_Type"].ToString();
                //// ...

            }
        }

        

        protected void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\jason\Downloads\School\sem 2 y2\BADPJ\BADPJ website\App_Data\GetGud.mdf; Integrated Security = True");

            sql.Open();

            if (Session["Account_Type"].ToString() == "User")
            {
                string cmddd =
                "UPDATE Customer SET Password = @Password WHERE Customer_ID = @Customer_ID";


                using (SqlCommand command = new SqlCommand(cmddd, sql))
                {

                    command.Parameters.AddWithValue("@Customer_ID", Session["Customer_ID"]);
                    command.Parameters.AddWithValue("@Password", tb_NewPassword.Text);

                    command.ExecuteNonQuery();

                    Session["Password"] = tb_NewPassword.Text;
                    Response.Redirect("UserProfile.aspx");


                }



            }
            else if (Session["Account_Type"].ToString() == "Coach")
            {
                string cmddd =
                "UPDATE Coach SET Password_Coach = @Password_Coach WHERE Id = @Id";


                using (SqlCommand command = new SqlCommand(cmddd, sql))
                {

                    command.Parameters.AddWithValue("@Id", Session["Id"]);
                    command.Parameters.AddWithValue("@Password_Coach", tb_NewPassword.Text);

                    command.ExecuteNonQuery();

                    Session["Password_Coach"] = tb_NewPassword.Text;
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