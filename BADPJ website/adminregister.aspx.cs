using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class adminregister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_SignUpAdming_Click(object sender, EventArgs e)
        {
            int result = 0;

            string Username_Admin = Tb_Username_Admin.Text;
            string Email_Admin = Tb_Email_Admin.Text;
            string Password_Admin = Tb_Password_Admin.Text;
            string Phone_No_Admin = Tb_PhoneNo_Admin.Text;

            Admin cust = new Admin(Username_Admin, Email_Admin, Password_Admin, Phone_No_Admin);

            result = cust.AdminInsert();

            if (result > 0)
            {

                Session["Regristration"] = cust;
                Session["Account_Type"] = "Admin";

                Response.Redirect("login.aspx");
            }
            else
            {
                Response.Write("<script>alert('Insert NOT successful');</script>");
            }
        }
    }
}