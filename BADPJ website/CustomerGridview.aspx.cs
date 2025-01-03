using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class CustomerGridview : System.Web.UI.Page
    {
        Customer aCust = new Customer();
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

        protected void bind()
        {
            List<Customer> custList = new List<Customer>();
            custList = aCust.getCustomerAll();
            
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Customer cust = new Customer();
            
            string categoryID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string customer_email = GridView1.Rows[e.RowIndex].Cells[2].Text;
            string paymentpayment = cust.customerPaymentDelete(customer_email).ToString();

            result = cust.customerDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Customer Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Customer Removal NOT successfully');</script>");
            }

            Response.Redirect("CustomerGridview.aspx");

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Customer cust = new Customer();
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            string Customer_ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string Username = ((TextBox)row.Cells[1].Controls[0]).Text;
            string Password = ((TextBox)row.Cells[3].Controls[0]).Text;
            string Phone_No = ((TextBox)row.Cells[4].Controls[0]).Text;

            result = cust.customerUpdate(Customer_ID, Username, Password, Phone_No);
            if (result > 0)
            {
                Response.Write("<script>alert('Customer updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Customer NOT updated');</script>");
            }
            GridView1.EditIndex = -1;
            bind();

        }


    
    }
}