using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class PaymentGridview : System.Web.UI.Page
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

        protected void bind()
        {
            List<Payment> payList = new List<Payment>();
            payList = aPay.getPaymentAll();
            payment_view.DataSourceID = null;
            payment_view.DataSource = payList;
            payment_view.DataBind();
        }

        protected void payment_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row.
            GridViewRow row = payment_view.SelectedRow;

            // Get Product ID from the selected row, which is the 
            // first row, i.e. index 0.
            string paymentID = row.Cells[0].Text;

            // Redirect to next page, with the Product Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("PaymentList.aspx?Payment_ID=" + paymentID);
        }

        protected void gv_paymentDelete(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Payment pay = new Payment();
            string categoryID = payment_view.DataKeys[e.RowIndex].Value.ToString();
            result = pay.paymentDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Payment Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Payment Removal NOT successful');</script>");
            }

            Response.Redirect("PaymentGridview.aspx");

        }

        protected void payment_view_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            payment_view.EditIndex = -1;
            bind();
        }

        protected void payment_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Payment pay = new Payment();

            try
            {
                GridViewRow row = (GridViewRow)payment_view.Rows[e.RowIndex];


                string id = payment_view.DataKeys[e.RowIndex].Value.ToString();
                int pid = int.Parse(payment_view.Rows[e.RowIndex].Cells[0].Text);
                string custemail = ((TextBox)row.Cells[1].Controls[0]).Text;
                string coachemail = ((TextBox)row.Cells[2].Controls[0]).Text;
                string payment_amount = ((TextBox)row.Cells[3].Controls[0]).Text;
                string payment_date = ((TextBox)row.Cells[4].Controls[0]).Text;

                string discount_given = ((TextBox)row.Cells[5].Controls[0]).Text;
                string platform_fee = ((TextBox)row.Cells[6].Controls[0]).Text;
                string status = ((TextBox)row.Cells[7].Controls[0]).Text;

                


                result = pay.PaymentUpdate(pid, custemail, coachemail,
                    payment_amount, payment_date, discount_given,
                    platform_fee, status);



                result = pay.PaymentUpdate(pid, custemail, coachemail,
                        payment_amount, payment_date, discount_given,
                        platform_fee, status);


                if (result > 0)
                {
                    Response.Write("<script>alert('Payment updated successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Payment NOT updated');</script>");
                }
                payment_view.EditIndex = -1;
                bind();
            }
            catch
            {
                Response.Write("<script>alert('Email does not exist or Values are not in correct format');</script>");
            }

        }



        protected void payment_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            payment_view.PageIndex = e.NewPageIndex;
            bind();
        }


        protected void payment_view_RowEditing(object sender, GridViewEditEventArgs e)
        {
            payment_view.EditIndex = e.NewEditIndex;
            bind();
        }

    }
}