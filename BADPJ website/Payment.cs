using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Collections;

namespace BADPJ_website
{
    public class Payment
    {
        private string _paymentID = "";
        private string _customer_email = "";
        private string _coach_email = "";
        private string _payment_date = null;
        private string _discount_given = "";
        private string _platform_fee = "";
        private string _paymentAmount = "";
        private string _status = "";

        string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

        public Payment(int payment_id, string customer_email, string coach_email, decimal paymentAmount, string payment_date, decimal discount_given, decimal platform_fee, string status)
        {
            _paymentID = payment_id.ToString();

            _customer_email = customer_email;
            _coach_email = coach_email;

            _paymentAmount = paymentAmount.ToString();
            _payment_date = payment_date;
            _discount_given = discount_given.ToString();
            _platform_fee = platform_fee.ToString();
            _status = status;


        }

        public Payment(int payment_id, string coach_email, decimal paymentAmount, string payment_date, decimal discount_given, string status)
        {
            _paymentID = payment_id.ToString();
            _coach_email = coach_email;
            _paymentAmount = paymentAmount.ToString();
            _payment_date = payment_date;
            _discount_given = discount_given.ToString();
            _status = status;


        }

        public Payment(string customer_email, string coach_email, decimal paymentAmount, string payment_date, decimal discount_given, decimal platform_fee)
        {

            _customer_email = customer_email;
            _coach_email = coach_email;
            _paymentAmount = paymentAmount.ToString();
            _payment_date = payment_date;
            _discount_given = discount_given.ToString();
            _platform_fee = platform_fee.ToString();
        }

        public Payment(string customer_email)
        {

            _customer_email = customer_email;
        }





        public Payment() { }

        public string Payment_ID
        {
            get { return _paymentID; }
            set { _paymentID = value; }
        }

        public string payment_amount
        {
            get { return _paymentAmount; }
            set { _paymentAmount = value; }

        }

        public string payment_date
        {
            get { return _payment_date; }
            set { _payment_date = value; }

        }


        public string customer_email
        {
            get { return _customer_email; }
            set { _customer_email = value; }

        }

        public string coach_email
        {
            get { return _coach_email; }
            set { _coach_email = value; }

        }




        public string discount_given
        {
            get { return _discount_given; }
            set { _discount_given = value; }
        }

        public string platform_fee
        {
            get { return _platform_fee; }
            set { _platform_fee = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }


        public int paymentInsert()
        {
            int result = 0;
            int paymentId = 0;



            string queryStr = "INSERT INTO Payment(customer_email, coach_email, payment_amount, payment_date, discount_given, platform_fee) "
                            + " OUTPUT INSERTED.payment_id "
                            + " VALUES (@customer_email, @coach_email, @payment_amount, @payment_date, @discount_given, @platform_fee) ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            cmd.Parameters.AddWithValue("@coach_email", this.coach_email);
            cmd.Parameters.AddWithValue("@customer_email", this.customer_email);
            cmd.Parameters.AddWithValue("@payment_amount", this.payment_amount);
            cmd.Parameters.AddWithValue("@payment_date", this.payment_date);
            cmd.Parameters.AddWithValue("@discount_given", this.discount_given);
            cmd.Parameters.AddWithValue("@platform_fee", this.platform_fee);

            conn.Open();
            paymentId = (int)cmd.ExecuteScalar(); // Returns the value of the inserted payment_id
            result = (paymentId > 0) ? 1 : 0;
            conn.Close();

            // Create a new cookie to store the payment ID
            HttpCookie cookie = new HttpCookie("LastPaymentId");
            cookie.Value = paymentId.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(cookie);

            return paymentId;
        }

        public Payment getPayment(int pid)
        {

            Payment paymentDetail = null;

            string customer_email, coach_email, payment_date, status;
            decimal payment_amount, platform_fee, discount_given;

            string queryStr = "SELECT * FROM Payment WHERE Payment_ID = @PaymentID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@PaymentID", pid);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                customer_email = dr["customer_email"].ToString();
                coach_email = dr["coach_email"].ToString();
                payment_amount = Convert.ToDecimal(dr["payment_amount"].ToString());
                payment_date = dr["payment_date"].ToString();
                discount_given = Convert.ToDecimal(dr["discount_given"]);
                platform_fee = Convert.ToDecimal(dr["platform_fee"]);
                status = dr["status"].ToString();

                paymentDetail = new Payment(pid, customer_email, coach_email, payment_amount, payment_date, discount_given, platform_fee, status);//sequence must be the same
            }
            else
            {
                paymentDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return paymentDetail;
        }

        public int paymentDelete(string ID)
        {
            string queryStr = "DELETE FROM Payment WHERE Payment_ID=@ID";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete

        public int PaymentUpdate(int pId, string custEmail, string coachEmail,
            string payment_amount, string payment_date,
            string discount_given, string platform_fee, string status)
        {

            if (status != "Paid" && status != "Not Paid")
            {
                int nofRow = 0;

                return nofRow;
            }
            else
            {
                string queryStr = "UPDATE Payment SET" +
                    " customer_email = @custEmail, " +
                    " coach_email = @coachEmail, " +
                    " payment_amount = @payment_amount, " +
                    " payment_date = @payment_date, " +

                    " discount_given = @discount_given, " +
                    " platform_fee = @platform_fee, " +
                    " status = @status " +
                    " WHERE Payment_ID = @paymentID";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@paymentID", pId);
                cmd.Parameters.AddWithValue("@custEmail", custEmail);
                cmd.Parameters.AddWithValue("@coachEmail", coachEmail);
                cmd.Parameters.AddWithValue("@payment_amount", payment_amount);
                cmd.Parameters.AddWithValue("@payment_date", payment_date);

                cmd.Parameters.AddWithValue("@discount_given", discount_given);
                cmd.Parameters.AddWithValue("@platform_fee", platform_fee);
                cmd.Parameters.AddWithValue("@status", status);

                conn.Open();
                int nofRow = 0;
                nofRow = cmd.ExecuteNonQuery();

                conn.Close();


                return nofRow;
            }
        }//end Update

        public int paymentStatusUpdate(int pId, string status)
        {
            string queryStr = "UPDATE Payment SET" +
                " status = @status " +
                " WHERE Payment_ID = @paymentID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@paymentID", pId);
            cmd.Parameters.AddWithValue("@status", status);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update

        public decimal GetTotalPaymentAmountByCustomer(string customer_email)
        {
            string queryStr = "SELECT SUM(payment_amount) FROM Payment WHERE customer_email = @customer_email AND status = 'Paid'";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);

            conn.Open();
            object result = cmd.ExecuteScalar();
            decimal totalAmount = result != DBNull.Value ? (decimal)result : 0;

            conn.Close();

            return totalAmount;
        }



        public List<Payment> getPaymentByCustomerEmail(string customer_email)
        {
            List<Payment> payList = new List<Payment>();

            string coach_email, payment_date, status, abc, abcd;
            int payment_id;
            decimal discount_given, payment_amount;

            string queryStr = "SELECT * FROM Payment WHERE customer_email = @customer_email Order By Payment_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@customer_email", customer_email);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                abc = dr["Payment_ID"].ToString();
                payment_id = int.Parse(abc);
                coach_email = dr["coach_email"].ToString();
                payment_amount = Convert.ToDecimal(dr["payment_amount"]);
                payment_date = dr["payment_date"].ToString();
                string discountString = dr["discount_given"].ToString();
                if (decimal.TryParse(discountString, out discount_given))
                {
                    // value was successfully parsed as a decimal
                }
                else
                {
                    // value could not be parsed as a decimal, assign a default value
                    discount_given = 0;
                }


                status = dr["status"].ToString();
                Payment a = new Payment(payment_id, coach_email, payment_amount, payment_date, discount_given,
                     status);
                payList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return payList;
        }




        public List<Payment> getPaymentAll()
        {
            List<Payment> payList = new List<Payment>();

            string customer_email, coach_email, payment_date
                , status, abc, abcd;
            int payment_id;
            decimal discount_given, platform_fee, payment_amount;


            string queryStr = "SELECT * FROM Payment Order By Payment_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                abc = dr["Payment_ID"].ToString();
                payment_id = int.Parse(abc);
                customer_email = dr["customer_email"].ToString();
                coach_email = dr["coach_email"].ToString();
                payment_amount = Convert.ToDecimal(dr["payment_amount"]);
                payment_date = dr["payment_date"].ToString();
                string discountString = dr["discount_given"].ToString();
                if (decimal.TryParse(discountString, out discount_given))
                {
                    // value was successfully parsed as a decimal
                }
                else
                {
                    // value could not be parsed as a decimal, assign a default value
                    discount_given = 0;
                }

                string platformFee = dr["platform_fee"].ToString();
                if (decimal.TryParse(platformFee, out platform_fee))
                {
                    // value was successfully parsed as a decimal
                }
                else
                {
                    // value could not be parsed as a decimal, assign a default value
                    platform_fee = 0;
                }

                status = dr["status"].ToString();
                Payment a = new Payment(payment_id, customer_email, coach_email,
                     payment_amount, payment_date, discount_given,
                     platform_fee, status);
                payList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return payList;
        }

    }
}