using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;
using System.Net.Http;
using Newtonsoft.Json;
using Stripe.Checkout;
using System.Data.SqlClient;


namespace BADPJ_website
{
    public partial class Payment1 : System.Web.UI.Page
    {
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

            var stripeSecretKey = "sk_test_51MYNugBFb0kjxJHqKA5BD4KP5C7WWrERBWylPycbONNcglR4dUWdoPpUP7MeUMDDMYD3aZaj188wBdb3Yo4q0OnD007BIR2ZU9";
            StripeConfiguration.ApiKey = stripeSecretKey;
            lbl_payment_date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            string payment_customer_email = (string)Session["customer_email"];
            lbl_customer_email.Text = payment_customer_email;
            string coach_email = (string)Session["coach_email_payment"];
            lbl_coach_email.Text = coach_email;
            decimal pre_payment_amount = (decimal)Session["coach_price"];
            
            decimal dc_payment_amount = 0;
            Payment pay = new Payment();
            decimal total_amount = pay.GetTotalPaymentAmountByCustomer(payment_customer_email);
            decimal dc_given = 0;
            decimal payment_amount = pre_payment_amount * (decimal)1.1;
            decimal platform_fee = pre_payment_amount * (decimal)0.1;
            lbl_platform_fee.Text = platform_fee.ToString("F");
            if (total_amount < 100)
            {
                lbl_discount_given.Text = "No Discount Given";
                dc_payment_amount = payment_amount;
            }
            else if (100 <= total_amount && total_amount < 200)
            {
                dc_payment_amount = payment_amount * (decimal)0.99;
                dc_given = payment_amount * (decimal)0.01;
                lbl_discount_given.Text = "$" + dc_given.ToString("F");
            }

            else if (200 <= total_amount && total_amount < 300)
            {
                dc_payment_amount = payment_amount * (decimal)0.98;
                dc_given = payment_amount * (decimal)0.02;
                lbl_discount_given.Text = "$" + dc_given.ToString("F");
            }
            else if (300 <= total_amount && total_amount < 400)
            {
                dc_payment_amount = payment_amount * (decimal)0.97;
                dc_given = payment_amount * (decimal)0.03;
                lbl_discount_given.Text = "$" + dc_given.ToString("F");
            }
            else if (400 <= total_amount)
            {
                dc_payment_amount = payment_amount * (decimal)0.95;
                dc_given = payment_amount * (decimal)0.05;
                lbl_discount_given.Text = "$" + dc_given.ToString("F");
            }

            lbl_payment_amount.Text = "$" + dc_payment_amount.ToString("F");



        }

        protected void btn_Payment(object sender, EventArgs e)
        {
            decimal discount_given = 0;
            int result = 0;
            string discountGiven = lbl_discount_given.Text;
            string paymentAmount = lbl_payment_amount.Text.Replace("$", "");
            string platformFee = lbl_platform_fee.Text.Replace("$", "");

            decimal payment_amount = decimal.Parse(paymentAmount);
            decimal platform_fee = decimal.Parse(platformFee);
            if (discountGiven == "No Discount Given")
            {

                discount_given = 0;
            }
            else
            {
                discountGiven = lbl_discount_given.Text.Replace("$", "");
                discount_given = decimal.Parse(discountGiven);
            }
            try
            {

                Payment pay = new Payment(lbl_customer_email.Text, lbl_coach_email.Text, payment_amount, lbl_payment_date.Text, discount_given, platform_fee);
                result = pay.paymentInsert();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    SqlException sqlEx = (SqlException)ex;
                    if (sqlEx.Number == 547)
                    {
                        Response.Write("<script>alert('Insert failed. Foreign key constraint violation');</script>");
                    }
                    else
                    {

                        Response.Write("<script>alert('Insert failed. Sql error');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Unknown error');</script>");
                }

            }







            StripeConfiguration.ApiKey = "sk_test_51MYNugBFb0kjxJHqKA5BD4KP5C7WWrERBWylPycbONNcglR4dUWdoPpUP7MeUMDDMYD3aZaj188wBdb3Yo4q0OnD007BIR2ZU9";

            var priceService = new PriceService();
            var priceOptions = new PriceCreateOptions
            {
                Currency = "sgd",
                UnitAmount = (int)(payment_amount * 100),
                Product = "prod_NLJ0Aaq0rqb0qO",
            };
            var price = priceService.Create(priceOptions);

            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
        {
          new SessionLineItemOptions
          {
            // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
            Price = price.Id,
            Quantity = 1,
          },
        },
                Mode = "payment",
                SuccessUrl = "https://localhost:44369/thank_you.aspx",
                CancelUrl = "https://localhost:44369/Payment.aspx",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Redirect(session.Url);








        }

        private class StripeCheckoutSession
        {
            public string Id { get; set; }
        }



    }


}