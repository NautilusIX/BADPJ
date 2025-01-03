using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class Create_Listing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            tb_CoachEmail.Text = Session["coach_email"].ToString();

            if (!!Page.IsPostBack)
            {
                if (Session["Account_Type"].ToString() != "Coach")
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
        }


        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            int result = 0;
            string coach_email = tb_CoachEmail.Text;
            string Coach_Desc = tb_CoachDesc.Text;
            string Coach_Image = FileUpload1.FileName;
            string Coach_Price = tb_CoachPrice.Text;
            string Coach_Name = tb_CoachName.Text;
            string Game = tb_Game.Text;
            string image = "";

            if (FileUpload1.HasFile == true)
            {

                image = "Images\\" + FileUpload1.FileName;
                Image1.ImageUrl = @"~\" + image;

                COACH_LISTING list = new COACH_LISTING(tb_CoachEmail.Text, tb_CoachDesc.Text,
                "/Images/" + FileUpload1.FileName, decimal.Parse(tb_CoachPrice.Text), tb_CoachName.Text, tb_Game.Text);
                result = list.ListingInsert();
                //execption handling to must include file

            }



            if (result > 0)
            {

                string saveimg = Server.MapPath(" ") + "\\" + image;
                lbl_Result.Text = saveimg.ToString();

                FileUpload1.SaveAs(saveimg);
                //loadProductInfo();
                //loadProduct();
                //clear1();
                Response.Write("<script>alert('Insert successful');</script>");
            }
            else
            {
                Response.Write("<script>alert('Insert NOT successful');</script>");
            }

        }

        protected void btn_ListView_Click(object sender, EventArgs e)
        {
            Response.Redirect("COACH_OWN_LISTING.aspx");
        }
    }
}