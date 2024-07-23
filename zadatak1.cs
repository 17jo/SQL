using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
namespace faza_7
{
    class zadatak1
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
                string strSQL = "SELECT ZAPOSLENI.IME, ZAPOSLENI.PREZIME " +
                                "FROM ZAPOSLENI,RADNIK_NA_SALTERU " +
                                "WHERE ZAPOSLENI.BROJ_LK = RADNIK_NA_SALTERU.BR_LK_RADNIKA AND ZAPOSLENI.ADRESA = '" + adresa + "'";
                OracleCommand cmd = new OracleCommand(strSQL, con);
                cmd.CommandType = System.Data.CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        string ime = dr.GetString(0);
                        string prezime = dr.GetString(1);
                        

                        Console.WriteLine(ime + " " + prezime);
                    }
                }
                else
                {
                    Console.WriteLine("Zaposleni sa zadatom adresom nije radnik na salteru");
                }

                dr.Close();
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

