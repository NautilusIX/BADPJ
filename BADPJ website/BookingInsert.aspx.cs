using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class BookingInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["Account_Type"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                tb_Price.Text = Session["coach_price"].ToString();
                //// Do something with the customerName in the session
                //string Account_Type = Session["Account_Type"].ToString();
                //// ...
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            Bookings prod = new Bookings(int.Parse(tb_BookingID.Text), tb_BookingTime.Text, int.Parse(tb_Duration.Text),
                decimal.Parse(tb_Price.Text), tb_Date.Text);
            result = prod.BookingInsert();

            if (result > 0)
            {
                string saveimg = Server.MapPath(" ") + "\\" + image;
                lbl_Result.Text = saveimg.ToString();
                //loadProductInfo();
                //loadProduct();
                //clear1();
                Response.Write("<script>alert('Insert successful');</script>");
                Response.Redirect("Payment.aspx");
            }
            else { Response.Write("<script>alert('Insert NOT successful');</script>"); }

        }

        protected void btn_ProductView_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookingView.aspx");
        }
    }
}