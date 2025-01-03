using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class MyPayments : System.Web.UI.Page
    {
        Payment aPay = new Payment();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }

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

        protected void btn_LOGOUT_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("login.aspx");
        }

        protected void Mypayment_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Mypayment_view.PageIndex = e.NewPageIndex;
            bind();
        }


        protected void bind()
        {
            string customer_email = (string)Session["customer_email"];
            List<Payment> payList = aPay.getPaymentByCustomerEmail(customer_email);
            Mypayment_view.DataSourceID = null;
            Mypayment_view.DataSource = payList;
            Mypayment_view.DataBind();
        }
    }
}