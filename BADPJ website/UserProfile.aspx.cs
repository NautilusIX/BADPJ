using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Account_Type"].ToString() == "User")
            {
               
                lbl_UserProfile.Text = Session["Username"].ToString();

                lbl_CustomerEmailProfile.Text = Session["customer_email"].ToString();
                lbl_PasswordProfile.Text = Session["Password"].ToString();
                lbl_Phone_NoProfile.Text = Session["Phone_No"].ToString();
            }
            else if (Session["Account_Type"].ToString() == "Coach")
            {
                lbl_UserProfile.Text = Session["Username_Coach"].ToString();

                lbl_CustomerEmailProfile.Text = Session["coach_email"].ToString();
                lbl_PasswordProfile.Text = Session["Password_Coach"].ToString();
                lbl_Phone_NoProfile.Text = Session["Phone_No_Coach"].ToString();

            }
            else
            {
                //// Do something with the customerName in the session
                //string Account_Type = Session["Account_Type"].ToString();
                //// ...
                Response.Redirect("Login.aspx");
            }

        }

        protected void btn_UserUpdateProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUserProfile.aspx");
        }

        protected void btn_LOGOUT_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }
    }
}