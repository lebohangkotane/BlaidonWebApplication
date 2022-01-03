using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlaidonWebApplication.Models
{
    public class ProductPackage
    {

        public int NumberProductOffering()
        {
            int numofRows;
            string numRs = "";

            SqlConnection conq = new SqlConnection();
            SqlDataReader drNR;
            void connectionStringAdmin()
            {
                conq.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();
            conq.Open();
            SqlCommand cmdNumR = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering'; ", conq);

            using (drNR = cmdNumR.ExecuteReader())
            {
                while (drNR.Read())
                {
                    numRs = drNR[0].ToString();
                }
            }


            numofRows = Convert.ToInt32(numRs);
            conq.Close();
            return numofRows;
        }
        public double NumberofOFOA(int gv)
        {
            double num;
            string numS = "";

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();

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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Large Format Printing'; ", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Mobile Bulk Filing Systems'; ", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Corpoate and Safety Clothing';", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Custom Made Furniture';", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Corporate Branding';", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Product Offering' AND Type = 'Promotional Items';", con);
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