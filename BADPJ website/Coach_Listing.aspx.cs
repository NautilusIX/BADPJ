using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class Coach_Listing : System.Web.UI.Page
    {
        COACH_LISTING aList = new COACH_LISTING();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bind()
        {
            List<COACH_LISTING> Lists = new List<COACH_LISTING>();
            Lists = aList.getListingAll();
            GridView2.DataSourceID = null;
            GridView2.DataSource = Lists;
            GridView2.DataBind();
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            COACH_LISTING list = new COACH_LISTING();
            string categoryID = GridView2.DataKeys[e.RowIndex].Value.ToString();
            result = list.ListingDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Listing removed successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Listing removal NOT successfully');</script>");
            }

            Response.Redirect("Coach_Listing.aspx");

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            e.Cancel = true;
            int result = 0;
            COACH_LISTING lists = new COACH_LISTING();
            GridViewRow row = (GridViewRow)GridView2.Rows[e.RowIndex];
            //string ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string listing_id = GridView2.DataKeys[e.RowIndex].Value.ToString();
            string cImage = ((TextBox)row.Cells[1].Controls[0]).Text;
            string cDesc = ((TextBox)row.Cells[2].Controls[0]).Text;
            string cPrice = ((TextBox)row.Cells[3].Controls[0]).Text;
            string cName = ((TextBox)row.Cells[4].Controls[0]).Text;
            string Game = ((TextBox)row.Cells[5].Controls[0]).Text;



            result = lists.ListingUpdate(listing_id, cDesc, cImage, decimal.Parse(cPrice), cName, Game);
            if (result > 0)
            {
                Response.Write("<script>alert('Listing updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Listing NOT updated');</script>");
            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}