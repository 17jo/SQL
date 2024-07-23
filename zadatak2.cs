using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
namespace faza_7
{
    class zadatak2
    {
        static void Main(string[] args)
        {
            OracleConnection con = null;
            string conString = "Data Source = 160.99.12.92/GISLAB_PD; User Id = SXXX; Password = XXX;";
            try
            {
                Console.WriteLine("Uneti adresu zaposlenog ");
                string adresa = Console.ReadLine();
                con = new OracleConnection(conString);
                con.Open();
                string strSQL;
                strSQL = "SELECT ZAPOSLENI.IME, ZAPOSLENI.PREZIME "+
                "FROM ZAPOSLENI,RADNIK_NA_SALTERU "+
                "WHERE ZAPOSLENI.BROJ_LK = RADNIK_NA_SALTERU.BR_LK_RADNIKA AND ZAPOSLENI.ADRESA = '"+adresa+"'";
                OracleDataAdapter da = new OracleDataAdapter(strSQL.ToString(), con);
                DataSet ds = new DataSet();
                da.Fill(ds, "ZAPOSLENI");
                con.Close();
                DataTable dtZaposleni = ds.Tables["ZAPOSLENI"];
                foreach (DataRow r in ds.Tables["ZAPOSLENI"].Rows)
                {  
                    string ime = (string)r["IME"];
                    string prezime = (string)r["PREZIME"];
                    Console.WriteLine(ime+ " " + prezime);
                }
            }
            catch (Exception ec)
            {
                Console.WriteLine("Doslo je do greske prilikom pristupanja bazi podataka" + ec.Message);
            }
            finally
            {
                if (con != null && con.State == System.Data.ConnectionState.Open)
                    con.Close();

                con = null;
            }
        }
    }
}

