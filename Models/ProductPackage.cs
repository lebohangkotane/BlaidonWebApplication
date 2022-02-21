using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace BlaidonWebApplication.Models
{
    public class ProductPackage
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BlaidonConnection"].ConnectionString;

        // SQL configerations (User)
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;
        public ProductPackage()
        {
            con = new SqlConnection(connectionString);
        }
        public int NumberProductOffering()
        {
            int numofRows;
            string numRs = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering'; ", con);

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
        public double NumberofOFOA(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Office Furniture and Office Accessories'; ", con);
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
        public double NumberofLFP(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Large Format Printing'; ", con);
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
        public double NumberofMBFS(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Mobile Bulk Filing Systems'; ", con);
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
        public double NumberofCSC(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Corpoate and Safety Clothing';", con);
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
        public double NumberofCMF(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Custom Made Furniture';", con);
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
        public double NumberofCB(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Corporate Branding';", con);
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
        public double NumberofPI(int gv)
        {
            double num;
            string numS = "";

            con.Open();
            cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Promotional Items';", con);
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