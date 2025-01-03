using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class ReviewInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            if (FileUpload1.HasFile == true)
            {
                image = "Images\\" + FileUpload1.FileName;
            }

            Product prod = new Product(tb_ProductID.Text, tb_ProductName.Text, tb_ProductDesc.Text,
                int.Parse(tb_UnitPrice.Text), FileUpload1.FileName, tb_StockLevel.Text);
            result = prod.ProductInsert();

            if (result > 0)
            {
                string saveimg = Server.MapPath(" ") + "\\" + image;
                lbl_Result.Text = saveimg.ToString();
                FileUpload1.SaveAs(saveimg);
                //loadProductInfo();
                //loadProduct();
                //clear1();
                Response.Redirect("Review.aspx");


            }
            else { Response.Write("<script>alert('Insert NOT successful');</script>"); }

        }

        protected void btn_ProductView_Click(object sender, EventArgs e)
        {
            Response.Redirect("Review.aspx");
        }
    }
}