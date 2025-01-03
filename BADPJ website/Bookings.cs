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
    public class Bookings
    {

        //Private string _connStr = Properties.Settings.Default.DBConnStr;

        //System.Configuration.ConnectionStringSettings _connStr;
        string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;
        private int _bookingId = 0;
        private string _bookingTime = "";
        private int _duration = 0;
        private decimal _price = 0;
        private string _bookingDate = "";


        // Default constructor
        public Bookings()
        {


        }

        // Constructor that take in all data required to build a Product object
        public Bookings(int bookingId, string bookingTime, int duration,
                       decimal price, string bookingDate)
        {
            _bookingId = bookingId;
            _bookingTime = bookingTime;
            _duration = duration;
            _price = price;
            _bookingDate = bookingDate;




        }

        // Constructor that take in all except product ID
        public Bookings(string bookingTime, int duration,
               decimal price, string bookingDate)
            : this(0, bookingTime, duration, price, bookingDate)
        {
        }

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public Bookings(int bookingId)
            : this(bookingId, "", 0, 0, "")
        {
        }

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public int Booking_ID
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }
        public string Booking_date
        {
            get { return _bookingDate; }
            set { _bookingDate = value; }
        }
        public string Booking_time
        {
            get { return _bookingTime; }
            set { _bookingTime = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }


        //Below as the Class methods for some DB operations. 
        public Bookings getBookings(int bookingId)
        {

            Bookings bookingDetail = null;

            string bookingTime;
            decimal price;
            int duration;
            string bookingDate;

            string queryStr = "SELECT * FROM Bookings WHERE Booking_ID = @BookingID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@BookingID", bookingId);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                bookingDate = dr["Booking_date"].ToString();
                bookingTime = dr["Booking_time"].ToString();
                duration = int.Parse(dr["Duration"].ToString());
                price = decimal.Parse(dr["Price"].ToString());


                bookingDetail = new Bookings(bookingId, bookingTime, duration, price, bookingDate);//sequence must be the same
            }
            else
            {
                bookingDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return bookingDetail;
        }

        public List<Bookings> getBookingsAll()
        {
            List<Bookings> bookingList = new List<Bookings>();

            string bookingTime;
            decimal price;
            int duration, bookingId;
            string bookingDate;

            string queryStr = "SELECT * FROM Bookings Order By Booking_ID";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                bookingId = int.Parse(dr["Booking_ID"].ToString());
                bookingDate = dr["Booking_date"].ToString();
                bookingTime = dr["Booking_time"].ToString();
                duration = int.Parse(dr["Duration"].ToString());
                price = decimal.Parse(dr["Price"].ToString());
                Bookings a = new Bookings(bookingId, bookingTime, duration, price, bookingDate);
                bookingList.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return bookingList;
        }

        public int BookingInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Bookings(Booking_ID,Booking_date, Booking_time, Duration, Price)"
                + " values (@Bookng_ID, @Booking_date, @Booking_time, @Duration, @Price)";
            //+ "values (@Bookng_ID, @Booking_date, @Booking_time, @Duration, @Price)";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@Bookng_ID", this.Booking_ID);
            cmd.Parameters.AddWithValue("@Booking_date", this.Booking_date);
            cmd.Parameters.AddWithValue("@Booking_time", this.Booking_time);
            cmd.Parameters.AddWithValue("@Duration", this.Duration);
            cmd.Parameters.AddWithValue("@Price", this.Price);

            conn.Open();
            result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
            conn.Close();

            return result;
        }//end Insert


        //everything can copy from this cs file
        public int BookingDelete(string Booking_ID)
        {
            string queryStr = "DELETE FROM Bookings WHERE Booking_ID=@Booking_Id";// if product is student just change to student, modification is only down here
            SqlConnection conn = new SqlConnection(_connStr);// must copy and paste
            SqlCommand cmd = new SqlCommand(queryStr, conn);// must copy and paste
            cmd.Parameters.AddWithValue("@Booking_Id", Booking_ID);
            conn.Open();//standard
            int nofRow = 0;//standard
            nofRow = cmd.ExecuteNonQuery();//standard
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete


        public int BookingUpdate(string bookingId, string bDate, int bDuration, string bTime)
        {
            string queryStr = "UPDATE Bookings SET" +
                " Booking_date = @bookingDate, " +
                " Duration = @duration, " +
                " Booking_time =@bookingtime" +
                " WHERE Booking_ID = @bookingId";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@bookingId", bookingId);
            cmd.Parameters.AddWithValue("@bookingDate", bDate);
            cmd.Parameters.AddWithValue("@duration", bDuration);
            cmd.Parameters.AddWithValue("@bookingtime", bTime);

            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update




        // destructor
        ~Bookings() { }

        // static construtor
        static Bookings() { }
    }
}