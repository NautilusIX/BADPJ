using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class see_Listing : System.Web.UI.Page
    {

        string conString = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
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

            if (!IsPostBack)
            {

                string query = "SELECT * FROM [Listing]";
                SqlCommand cmd = new SqlCommand(query);

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);
                            DataList1.DataSource = ds;
                            DataList1.DataBind();



                        }
                    }
                }




                string query1 = "SELECT distinct(Game) FROM [Listing]";
                SqlCommand cmd1 = new SqlCommand(query1);

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd1.Connection = con;
                        sda.SelectCommand = cmd1;
                        using (DataSet ds = new DataSet())
                        {
                            sda.Fill(ds);

                            ddlgames.AppendDataBoundItems = true;
                            ddlgames.Items.Insert(0, new ListItem("All", String.Empty));

                            ddlgames.DataSource = ds;

                            ddlgames.DataTextField = "Game";
                            ddlgames.DataBind();



                        }
                    }
                }



                DataList1.Visible = true;
                lbnotfound.Visible = false;

            }
        }

        protected void ddllh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";
            if (ddllh.SelectedValue == "LH")
            {
                query = "SELECT * FROM [Listing] order by Coach_Price ";

            }
            else if (ddllh.SelectedValue == "HL")
            {
                query = "SELECT * FROM [Listing] order by Coach_Price desc";

            }
            else
            {
                query = "SELECT * FROM [Listing]";
            }
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        DataList1.DataSource = ds;
                        DataList1.DataBind();
                        DataList1.Visible = true;
                        lbnotfound.Visible = false;
                    }
                }
            }

        }

        protected void ddlgames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "";
            if (!string.IsNullOrEmpty(ddlgames.Text) && ddlgames.Text != "All")
            {
                query = "SELECT * FROM [Listing] where Game like '%" + ddlgames.Text + "' ";

            }
            else
            {
                query = "SELECT * FROM [Listing]";
            }
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        DataList1.DataSource = ds;
                        DataList1.DataBind();
                        DataList1.Visible = true;
                        lbnotfound.Visible = false;
                    }
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            string query = "";
            if (!string.IsNullOrEmpty(txtsearch.Value))
            {
                query = "SELECT * FROM [Listing] where Coach_Name = '" + txtsearch.Value + "' ";

            }
            else
            {
                query = "SELECT * FROM [Listing]";
            }
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataList1.DataSource = ds;
                            DataList1.DataBind();
                            DataList1.Visible = true;
                            lbnotfound.Visible = false;
                        }
                        else
                        {
                            DataList1.Visible = false;
                            lbnotfound.Visible = true;
                        }
                    }
                }
            }

        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }


        protected void BtnBook_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataListItem item = (DataListItem)btn.NamingContainer;
            Label emailLabel = (Label)item.FindControl("emailLabel");
            Session["coach_email_payment"] = emailLabel.Text;
            Label priceLabel2 = (Label)item.FindControl("priceLabel2");
            Session["coach_price"] = decimal.Parse(priceLabel2.Text);
            Label gameLabel = (Label)item.FindControl("gameLabel");
            Session["game"] = gameLabel.Text;
            Label nameLabel = (Label)item.FindControl("nameLabel");
            Session["coach_name"] = nameLabel.Text;

            Response.Redirect("BookingInsert.aspx");
        }


    }
}