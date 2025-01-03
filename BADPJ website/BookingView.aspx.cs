using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class BookingView : System.Web.UI.Page
    {
        Bookings aProd = new Bookings();
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
            List<Bookings> bookingList = new List<Bookings>();
            bookingList = aProd.getBookingsAll();
            gvProduct.DataSource = bookingList;
            gvProduct.DataBind();
        }

        protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row.
            GridViewRow row = gvProduct.SelectedRow;

            // Get Product ID from the selected row, which is the 
            // first row, i.e. index 0.
            string bookingId = row.Cells[0].Text;

            // Redirect to next page, with the Product Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("BookingDetails.aspx?BookingID=" + bookingId);
        }

        protected void btn_AddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookingInsert.aspx");
        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Bookings prod = new Bookings();
            string categoryID = gvProduct.DataKeys[e.RowIndex].Value.ToString();
            result = prod.BookingDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Product Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product Removal NOT successfully');</script>");
            }

            Response.Redirect("BookingView.aspx");

        }

        protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProduct.EditIndex = e.NewEditIndex;
            bind();

        }

        protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProduct.EditIndex = -1;
            bind();

        }

        protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Bookings prod = new Bookings();
            GridViewRow row = (GridViewRow)gvProduct.Rows[e.RowIndex];
            string bId = gvProduct.DataKeys[e.RowIndex].Value.ToString();
            string bDate = ((TextBox)row.Cells[1].Controls[0]).Text;
            int bDuration = int.Parse(((TextBox)row.Cells[4].Controls[0]).Text);
            string bTime = ((TextBox)row.Cells[3].Controls[0]).Text;

            result = prod.BookingUpdate(bId, bDate, bDuration, bTime);
            if (result > 0)
            {
                Response.Write("<script>alert('Product updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product NOT updated');</script>");
            }
            gvProduct.EditIndex = -1;
            bind();

        }
    }
}