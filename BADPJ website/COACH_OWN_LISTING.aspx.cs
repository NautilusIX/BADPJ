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
    public partial class COACH_OWN_LISTING2 : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //ImageCoach.ImageUrl = Session["Coach_Image"].ToString();
            //lbl_coachListingName.Text = Session["Coach_Name"].ToString();
            //lbl_coachListingEmail.Text = Session["coach_email"].ToString();
            //lbl_coachListingDesc.Text = Session["Coach_Desc"].ToString();
            //lbl_coachListingPrice.Text = Session["Coach_Price"].ToString();
            //lbl_coachListingGame.Text = Session["Game"].ToString();
            if (Session["coach_price"] == null)
            {
                Session["coach_price"] = "";
            }
            else
            {

                lbl_Test.Text = Session["coach_price"].ToString();
            }

            if (!Page.IsPostBack)
            {
                refreshdata();
            }
        }
        public void refreshdata()
        {
            SqlConnection con = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand("select * from listing where coach_email='" + Session["coach_email"] + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();


        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(_connStr);
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["Listing_ID"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from listing where Listing_ID =@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            refreshdata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            refreshdata();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            refreshdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(_connStr);

            TextBox coach_email = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
            TextBox Coach_Desc = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
            TextBox Coach_Price = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
            TextBox Coach_Image = GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
            TextBox Coach_Name = GridView1.Rows[e.RowIndex].FindControl("TextBox7") as TextBox;
            TextBox Game = GridView1.Rows[e.RowIndex].FindControl("TextBox8") as TextBox;
            int id = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Values["Listing_ID"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Update listing set coach_email=@coach_email,Coach_Desc=@Coach_Desc," +
                "Coach_Price=@Coach_Price,Coach_Image=@Coach_Image,Coach_Name=@Coach_Name,Game=@Game where Listing_ID =@id", con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@coach_email", coach_email.Text);
            cmd.Parameters.AddWithValue("@Coach_Desc", Coach_Desc.Text);
            cmd.Parameters.AddWithValue("@Coach_Price", Coach_Price.Text);
            cmd.Parameters.AddWithValue("@Coach_Image", Coach_Image.Text);
            cmd.Parameters.AddWithValue("@Coach_Name", Coach_Name.Text);
            cmd.Parameters.AddWithValue("@Game", Game.Text);
            cmd.Parameters.AddWithValue("@id", id);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            refreshdata();


        }
        protected void btn_coachListingUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateUserProfile.aspx");
        }
    }
}