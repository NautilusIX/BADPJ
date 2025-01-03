using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account_Type"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["Account_Type"].ToString() == "User")
            {
                lblUsername.Text = Session["Username"].ToString();
            } 
            else if(Session["Account_Type"].ToString() == "Coach")
            {
                lblUsername.Text = Session["Username_Coach"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btn_SignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
    }
}