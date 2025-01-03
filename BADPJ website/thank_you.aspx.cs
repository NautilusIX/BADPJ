using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class thank_you : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["LastPaymentId"] != null)
                {
                    lbl_payment_id_success.Text = Request.Cookies["LastPaymentId"].Value;
                }
                else
                {
                    lbl_payment_id_success.Text = "No cookies";
                }
                int result = 0;
                int pid = int.Parse(lbl_payment_id_success.Text);
                string status = "Paid";
                Payment pay = new Payment();
                result = pay.paymentStatusUpdate(pid, status);
                Payment spay = null;
                Payment apay = new Payment();
                // Get Product ID from querystring



                spay = apay.getPayment(pid);

                lbl_customer_email_success.Text = spay.customer_email.ToString();
                lbl_coach_email_success.Text = spay.coach_email.ToString();
                lbl_payment_amount_success.Text = "$" + spay.payment_amount.ToString();
                lbl_payment_date_success.Text = spay.payment_date.ToString();
                lbl_platform_fee_success.Text = "$" + spay.platform_fee.ToString();
                lbl_discount_given_success.Text = "$" + spay.discount_given.ToString();
                lbl_status_success.Text = spay.status.ToString();

                if (result > 0)
                {
                    Response.Write("<script>alert('Payment successful');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Payment NOT successful');</script>");
                }

            }
        }
    }
}