using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BlaidonWebApplication.Models
{
    public class ServicePackage
    {

        string connectionString = ConfigurationManager.ConnectionStrings["BlaidonConnection"].ConnectionString;

        // SQL configerations (User)
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        public ServicePackage()
        {
            con = new SqlConnection(connectionString);
        }
        public int NumberServiceOffering()
        {
            int numofRows;
            string numRs = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering';", con);

            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numRs = dr[0].ToString();
                }
            }

            numofRows = Convert.ToInt32(numRs);
            con.Close();
            return numofRows;
        }
        public double NumberofPlbmg(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Plumbing'; ", con);
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numS = dr[0].ToString();
                }
            }

            num = Convert.ToDouble(numS);
            double dgv = Convert.ToDouble(gv);
            double mathdvd = num / dgv;
            double math = mathdvd * 100;
            double numRound = Math.Round(math, 2);
            con.Close();
            return numRound;
        }
        public double NumberofPtng(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Painting'; ", con);
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numS = dr[0].ToString();
                }
            }

            num = Convert.ToDouble(numS);
            double dgv = Convert.ToDouble(gv);
            double mathdvd = num / dgv;
            double math = mathdvd * 100;
            double numRound = Math.Round(math, 2);
            con.Close();
            return numRound;
        }
        public double NumberofElctl(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Electrical'; ", con);
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numS = dr[0].ToString();
                }
            }

            num = Convert.ToDouble(numS);
            double dgv = Convert.ToDouble(gv);
            double mathdvd = num / dgv;
            double math = mathdvd * 100;
            double numRound = Math.Round(math, 2);
            con.Close();
            return numRound;
        }
        public double NumberofFlrng(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Flooring';", con);
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numS = dr[0].ToString();
                }
            }

            num = Convert.ToDouble(numS);
            double dgv = Convert.ToDouble(gv);
            double mathdvd = num / dgv;
            double math = mathdvd * 100;
            double numRound = Math.Round(math, 2);
            con.Close();
            return numRound;
        }
        public double NumberofDwllng(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Dry Walling';", con);
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numS = dr[0].ToString();
                }
            }

            num = Convert.ToDouble(numS);
            double dgv = Convert.ToDouble(gv);
            double mathdvd = num / dgv;
            double math = mathdvd * 100;
            double numRound = Math.Round(math, 2);
            con.Close();
            return numRound;
        }
        public double NumberofBldng(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Building';", con);
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numS = dr[0].ToString();
                }
            }

            num = Convert.ToDouble(numS);
            double dgv = Convert.ToDouble(gv);
            double mathdvd = num / dgv;
            double math = mathdvd * 100;
            double numRound = Math.Round(math, 2);
            con.Close();
            return numRound;
        }
        public double NumberofRvntn(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Renovation';", con);
            using (dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    numS = dr[0].ToString();
                }
            }

            num = Convert.ToDouble(numS);
            double dgv = Convert.ToDouble(gv);
            double mathdvd = num / dgv;
            double math = mathdvd * 100;
            double numRound = Math.Round(math, 2);
            con.Close();
            return numRound;
        }
    }
}