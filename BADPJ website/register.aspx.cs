using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BADPJ_website
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        String randomCode;
        public static String to;
        
        

        protected void Btn_SignUp_Click(object sender, EventArgs e)
        {
            if (Tb_OTP.Text == ""){
                lbl_Message.Text = "Verify OTP";
            }
            else if (Session["Code"].ToString() == (Tb_OTP.Text).ToString())
            {
                to = Tb_Email.Text;
                lbl_Message.Text = "OTP Correct";

                int result = 0;

                string Username = Tb_Username.Text;
                string customer_Email = Tb_Email.Text;
                string Password = Tb_Password.Text;
                string Phone_No = Tb_PhoneNo.Text;

                Customer cust = new Customer(Username, customer_Email, Password, Phone_No);

                result = cust.CustomerInsert();

                if (result > 0)
                {

                    Response.Redirect("login.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Insert NOT successful');</script>");
                }
            }
            else
            {
                lbl_Message.Text = "OTP NOT Correct";
            }

            
        }

        protected void Btn_GetOTP_Click(object sender, EventArgs e)
        {
            String from, pass, messageBody;
            Random rand = new Random();

            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (Tb_Email.Text).ToString();
            from = "getgudwithus@gmail.com"; // own email
            pass = "xxguqcnvjdcfqaco";
            messageBody = "Your OTP is : " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Email Confirmation Code";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                lbl_Message.Text = "OTP Sent Successfully";
                Session["Code"] = randomCode;
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
                lbl_Message.Text = "OTP NOT Sent Successfully";
            }


        }

        //protected void Btn_VerifyOTP_Click(object sender, EventArgs e)
        //{
        //    if (Session["Code"].ToString() == (Tb_OTP.Text).ToString())
        //    {
        //        to = Tb_Email.Text;
        //        lbl_Message.Text = "OTP Correct";
        //    }
        //    else
        //    {
        //        lbl_Message.Text = "OTP NOT Correct";
        //    }
        //}
    }
}