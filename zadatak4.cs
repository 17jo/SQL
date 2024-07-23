using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
namespace faza_7
{
    class zadatak4
    {
        static void Main(string[] args)
        {
            OracleConnection con = null;
            string strConnection = "Data Source = 160.99.12.92/GISLAB_PD; User Id = SXXX; Password = XXX;";
       
            try
            {
                Console.WriteLine("Uneti ime pa prezime zaposlenog kome zelite da promenite broj tel: ");
                string ime = Console.ReadLine();
                string prezime = Console.ReadLine();
                
                Console.WriteLine("Unesite broj telefona: ");
                int broj = Int32.Parse(Console.ReadLine());

               con = new OracleConnection(strConnection);
                    con.Open();
                string strSQL = "SELECT BROJ_TEL,LK_ZAPOSLENI FROM BROJ_TEL_ZAPOSLENOG " +
            "WHERE LK_ZAPOSLENI = (SELECT LK_ZAPOSLENI FROM BROJ_TEL_ZAPOSLENOG INNER JOIN ZAPOSLENI ON ZAPOSLENI.BROJ_LK = BROJ_TEL_ZAPOSLENOG.LK_ZAPOSLENI WHERE ZAPOSLENI.IME = '" + ime + "'" +
               "AND ZAPOSLENI.PREZIME = '" + prezime + "')";

                OracleDataAdapter da = new OracleDataAdapter(strSQL, con);
                    OracleCommandBuilder builder = new OracleCommandBuilder(da);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "BROJ_TEL_NOVI");
                    foreach (DataRow r in ds.Tables["BROJ_TEL_NOVI"].Rows)
                    {
                        r["BROJ_TEL"] = (int)broj;
                       
                    }
                    da.Update(ds, "BROJ_TEL_NOVI");
                    con.Close();
                    Console.WriteLine("Azurirano");

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

