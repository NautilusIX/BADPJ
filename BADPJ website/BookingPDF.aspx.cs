using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


using System.Data;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace BADPJ_website
{
    public partial class BookingPDF : System.Web.UI.Page
    {
        static Boolean bookingidfound;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label5.Text = TextBox1.Text;
            findorderdate(Label5.Text);
            if (bookingidfound == true)
            {
                findaddress(Label5.Text);
                showgrid(Label5.Text);
                Panel1.Visible = true;

            }
            else
            {
                Label9.Text = "Booking ID Not Found";
            }
        }

        private void findaddress(String bookingid)
        {
            String mycon = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString; //when u declare it gos to ur web.config and find the string to the connection
            String myquery = "Select * from Bookings where Booking_ID='" + bookingid + "'";
            SqlConnection con = new SqlConnection(mycon); //plugging into the date base connection(Establishing connection with database)
            SqlCommand cmd = new SqlCommand(); //creating a object that represent sql command
            cmd.CommandText = myquery; //refers to an attribute, whatever that discribes the object, cmd actually have this attribute commandtext which represents my SQL statement
            cmd.Connection = con; // attribute is describe by another object, which you have to look to that object to understand another object, im a boy but can be another object which is poly student

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(); //calling the method to the object, im a human, my method is that I an code, functions that belong to that object, its a pointer from my database, technically results


            if (dr.Read())
            {
                String bookingdate = dr["Price"].ToString();
                Label7.Text = bookingdate;

            }
            else
            {
                Label7.Text = "Nothing found";
            }




            con.Close();
            dr.Close();
            dr.Dispose();
        }

        private void showgrid(String bookingid)
        {
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add("Booking_ID");
            dt.Columns.Add("Booking_date");
            dt.Columns.Add("Booking_time");
            dt.Columns.Add("Duration");
            dt.Columns.Add("Price");
            String mycon = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
            SqlConnection scon = new SqlConnection(mycon);
            String myquery = "select * from Bookings where Booking_ID='" + bookingid + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = scon;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int totalrows = ds.Tables[0].Rows.Count;
            int i = 0;
            int grandtotal = 0;
            while (i < totalrows)
            {
                dr = dt.NewRow();
                dr["Booking_ID"] = ds.Tables[0].Rows[i]["Booking_ID"].ToString();
                dr["Booking_date"] = ds.Tables[0].Rows[i]["Booking_date"].ToString();
                dr["Booking_time"] = ds.Tables[0].Rows[i]["Booking_time"].ToString();
                dr["Duration"] = ds.Tables[0].Rows[i]["Duration"].ToString();
                dr["Price"] = ds.Tables[0].Rows[i]["Price"].ToString();

                dt.Rows.Add(dr);
                i = i + 1;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private void findorderdate(String bookingid)
        {
            String mycon = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
            String myquery = "Select * from Bookings where Booking_ID='" + bookingid + "'";
            SqlConnection con = new SqlConnection(mycon);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                Label6.Text = ds.Tables[0].Rows[0]["Booking_date"].ToString();
                bookingidfound = true;
            }
            else
            {
                bookingidfound = false;
            }

            con.Close();
        }

        private void exportpdf()
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=OrderInvoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            Panel1.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            exportpdf();
        }
    }
}