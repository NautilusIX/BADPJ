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
    public class COACH_LISTING
    {
        private string _listing_id = "";
        private string _coach_email = "";
        private string _coachDesc = ""; // this is another way to specify empty string
        private decimal _coachPrice = 0;
        private string _coachImage = "";
        private string _coachName = "";
        private string _Game = "";

        string _connStr = ConfigurationManager.ConnectionStrings["GetGudDB"].ConnectionString;

        public COACH_LISTING()
        {

        }
        public COACH_LISTING(string listing_id, string coach_email, string coachDesc,
                   string coachImage, decimal coachPrice, string coachName, string Game)
        {

            _listing_id = listing_id;
            _coach_email = coach_email;
            _coachDesc = coachDesc;
            _coachImage = coachImage;
            _coachPrice = coachPrice;
            _coachName = coachName;
            _Game = Game;

        }

        public COACH_LISTING(string coach_email, string coachDesc,
                    string coachImage, decimal coachPrice, string coachName, string Game)
        {


            _coach_email = coach_email;
            _coachDesc = coachDesc;
            _coachImage = coachImage;
            _coachPrice = coachPrice;
            _coachName = coachName;
            _Game = Game;
        }

        public string listing_id
        {
            get { return _listing_id; }
            set { _listing_id = value; }
        }
        public string coach_email
        {
            get { return _coach_email; }
            set { _coach_email = value; }
        }

        public string Coach_Desc
        {
            get { return _coachDesc; }
            set { _coachDesc = value; }
        }

        public decimal Coach_Price
        {
            get { return _coachPrice; }
            set { _coachPrice = value; }
        }
        public string Coach_Image
        {
            get { return _coachImage; }
            set { _coachImage = value; }
        }
        public string Coach_Name
        {
            get { return _coachName; }
            set { _coachName = value; }
        }

        public string Game
        {
            get { return _Game; }
            set { _Game = value; }
        }

        public List<COACH_LISTING> getListingAll()
        {
            List<COACH_LISTING> Lists = new List<COACH_LISTING>();

            string listing_id, coach_email, coach_Desc, coach_Name, coach_Image, game;
            decimal coach_Price;


            string queryStr = "SELECT * FROM Listing Order By Coach_Name";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listing_id = dr["listing_id"].ToString();
                coach_email = dr["coach_email"].ToString();
                coach_Desc = dr["Coach_Desc"].ToString();
                coach_Name = dr["coach_Name"].ToString();
                coach_Image = dr["coach_Image"].ToString();
                coach_Price = decimal.Parse(dr["coach_Price"].ToString());
                game = dr["Game"].ToString();


                COACH_LISTING a = new COACH_LISTING(listing_id, coach_email, coach_Desc, coach_Image, coach_Price, coach_Name, game);
                Lists.Add(a);
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return Lists;
        }

        public int ListingInsert()
        {

            // string msg = null;
            int result = 0;

            string queryStr = "INSERT INTO Listing(coach_email, Coach_Desc, Coach_Image, Coach_Price, Coach_Name, Game)"
                + " values ( @coach_email, @Coach_Desc, @Coach_Image, @Coach_Price,@Coach_Name,@Game)";
            //+ "values (@Listing_ID,@Email_Coach, @Coach_Desc, @Coach_Image, @Coach_Price,@Coach_Name)";


            try
            {
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                // cmd.Parameters.AddWithValue("@Listing_ID", this.Listing_ID);
                cmd.Parameters.AddWithValue("@coach_email", this.coach_email);
                cmd.Parameters.AddWithValue("@Coach_Desc", this.Coach_Desc);
                cmd.Parameters.AddWithValue("@Coach_Image", this.Coach_Image);
                cmd.Parameters.AddWithValue("@Coach_Price", this.Coach_Price);
                cmd.Parameters.AddWithValue("@Coach_Name", this.Coach_Name);
                cmd.Parameters.AddWithValue("@Game", this.Game);

                conn.Open();
                result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0
                conn.Close();
            }

            catch (Exception ex)
            {

                result = 0;
                // can write additonal error message by having a parameter called exception then do ex.m

            }
            return result;



        }//end Insert

        public int ListingUpdate(string listing_id, string cDesc, string cImage, decimal cPrice, string cName, string Game)
        {
            string queryStr = "UPDATE Listing SET " + "Coach_Desc = @coachDesc," + "Coach_Price = @coachPrice," + "Coach_Name  = @coachName," + "Game  = @Game" + " WHERE listing_id = @listing_id ";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@coachDesc", cDesc);
            cmd.Parameters.AddWithValue("@coachImage", cImage);
            cmd.Parameters.AddWithValue("@coachPrice", cPrice);
            cmd.Parameters.AddWithValue("@coachName", cName);
            cmd.Parameters.AddWithValue("@Game", Game);
            cmd.Parameters.AddWithValue("@listing_id", listing_id);


            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Update


        public int ListingDelete(string listing_id)
        {
            string queryStr = "DELETE FROM Listing WHERE listing_id = @listing_id";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@listing_id", listing_id);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();
            //  Response.Write("<script>alert('Delete successful');</script>");
            conn.Close();
            return nofRow;

        }//end Delete


        // destructor
        ~COACH_LISTING() { }

        // static construtor
        static COACH_LISTING() { }
    }
}

