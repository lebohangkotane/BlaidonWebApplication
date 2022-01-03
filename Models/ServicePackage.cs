using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BlaidonWebApplication.Models
{
    public class ServicePackage
    {
        public int NumberServiceOffering()
        {
            int numofRows;
            string numRs = "";

            SqlConnection conq = new SqlConnection();
            SqlDataReader drNR;
            void connectionStringAdmin()
            {
                //conq.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                conq.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();
            conq.Open();
            SqlCommand cmdNumR = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering';", conq);

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
        public double NumberofPlbmg(int gv)
        {
            double num;
            string numS = "";

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Plumbing'; ", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();

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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Electrical'; ", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Flooring';", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Dry Walling';", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();

            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(type) FROM tblEnquiries WHERE Category = 'Service Offering' AND Type = 'Building';", con);
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

            SqlConnection con = new SqlConnection();
            SqlDataReader dr;
            void connectionStringAdmin()
            {
                //con.ConnectionString = "data source = VANSTHEMACHINE; database = Blaidon; integrated security = SSPI;";
                con.ConnectionString = "Server = tcp:blaidon.database.windows.net,1433; Initial Catalog = Blaidon; Persist Security Info = False; User ID = Blaidon; Password =#ViwemeAdmin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }
            connectionStringAdmin();

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