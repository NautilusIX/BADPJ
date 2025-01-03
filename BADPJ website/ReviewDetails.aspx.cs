using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class ReviewDetails : System.Web.UI.Page
    {
        Product prod = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Product aProd = new Product();
            // Get Product ID from querystring

            if (Request.QueryString["ProdID"] == null)
            {
                Response.Redirect("ProductView.aspx");
            }

            string prodID = Request.QueryString["ProdID"].ToString();
            prod = aProd.getProduct(prodID);

            lbl_ProdName.Text = prod.Product_Name;
            lbl_ProdDesc.Text = prod.Product_Desc;
            lbl_Price.Text = prod.Unit_Price.ToString();
            img_Product.ImageUrl = "~\\Images\\" + prod.Product_Image;
            lbl_StockLevel.Text = prod.Stock_Level;
            lbl_ProdID.Text = prodID.ToString();



        }

        protected void btn_reviewback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Review.aspx");
        }
    }
}