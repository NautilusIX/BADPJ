using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class Coach : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account_Type"].ToString() == "User")
            {
                lbl_CoachUser.Text = Session["Username"].ToString();
            }
            else if (Session["Account_Type"].ToString() == "Coach")
            {
                lbl_CoachUser.Text = Session["Username_Coach"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btn_exit_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
               
        }
    }
}