using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;
using System.Web.Services;
using Newtonsoft.Json;


using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace BADPJ_website
{
    public partial class admintesting : System.Web.UI.Page
    {
        protected int AdminCount;
        protected int CustomerCount;
        protected int CoachCount;
        protected int PaymentCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Account_Type"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                
                //// Do something with the customerName in the session
                //string Account_Type = Session["Account_Type"].ToString();
                //// ...
            }

            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Admin", connection))
                {
                    AdminCount = (int)command.ExecuteScalar();
                }

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Customer", connection))
                {
                    CustomerCount = (int)command.ExecuteScalar();
                }

                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Coach", connection))
                {
                    CoachCount = (int)command.ExecuteScalar();
                }
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Payment", connection))
                {
                    PaymentCount = (int)command.ExecuteScalar();
                }
            }
        }

        [WebMethod()]
        public static string GetPaymentData() 
        {
            List<PaymentChartData> li = new List<PaymentChartData>();

            string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                
                using (SqlCommand command = new SqlCommand("SELECT sum(payment_amount) as payment_amount,payment_date FROM Payment WHERE status = 'Paid' group by payment_date", connection))
                {
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            PaymentChartData pc = new PaymentChartData();
                            pc.PaymentDate = dr["payment_date"].ToString();
                            pc.Value = Convert.ToDecimal(dr["payment_amount"]);
                            li.Add(pc);
                        }

                    }
                }
            }

            return JsonConvert.SerializeObject( li );
        }
    }
}