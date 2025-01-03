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
    public partial class coachregister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        String randomCode;
        public static String to;
        protected void btn_Insert_Click(object sender, EventArgs e)
        {

            if (Tb_OTP_Coach.Text == "")
            {
                lbl_Message.Text = "Verify OTP";
            }
            else if (Session["CodeCoach"].ToString() == (Tb_OTP_Coach.Text).ToString())
            {
                to = tb_CoachEmail.Text;
                lbl_Message.Text = "OTP Correct";


                int result = 0;
                CCoach obj = new CCoach();
                obj.name = tb_CoachName.Text;
                obj.email = tb_CoachEmail.Text;
                obj.pass = tb_Password.Text;
                obj.phone = tb_Phone.Text;
                result = obj.CoachInsert();

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



        protected void Btn_GetOTP_Coach_Click(object sender, EventArgs e)
        {
            String from, pass, messageBody;
            Random rand = new Random();

            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (tb_CoachEmail.Text).ToString();
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
                Session["CodeCoach"] = randomCode;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                lbl_Message.Text = "OTP NOT Sent Successfully";
            }


        }

        protected void Btn_VerifyOTP_Coach_Click(object sender, EventArgs e)
        {
            if (Session["CodeCoach"].ToString() == (Tb_OTP_Coach.Text).ToString())
            {
                to = tb_CoachEmail.Text;
                lbl_Message.Text = "OTP Correct";
                lbl_Message.Text = "OTP NOT Sent Successfully";
            }
            else
            {
                lbl_Message.Text = "OTP NOT Correct";
            }
        }
    }
}