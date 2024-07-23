using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
namespace faza_7
{
    class zadatak5
    {
        static void Main(string[] args)
        {
            OracleConnection con = null;
            string conString = "Data Source = 160.99.12.92/GISLAB_PD; User Id = SXXX; Password = XXX;";
            try
            {
                Console.WriteLine("Uneti ime pa prezime putnika kojem zelite da obrisete broj telefona :");
                string ime = Console.ReadLine();
                string prezime = Console.ReadLine();
                    con = new OracleConnection(conString);
                    con.Open();
                    StringBuilder strSQL = new StringBuilder();
                    strSQL.Append("DELETE FROM BROJ_TEL_PUTNIKA ");
                    strSQL.Append(" WHERE JMBG_PUTNIKA=(SELECT JMBG_PUTNIKA FROM BROJ_TEL_PUTNIKA INNER JOIN PUTNIK ON ");
                    strSQL.Append(" JMBG_PUTNIKA=JMBG WHERE PUTNIK.IME = :ime AND PUTNIK.PREZIME = :prezime) ");
                    OracleCommand cmd = new OracleCommand(strSQL.ToString(), con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    OracleParameter parIme = new OracleParameter("ime", OracleDbType.Char);
                    OracleParameter parPrezime = new OracleParameter("prezime", OracleDbType.Char);
                    parIme.Value = ime;
                    parPrezime.Value = prezime;
                    cmd.Parameters.Add(parIme);
                    cmd.Parameters.Add(parPrezime);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Azurirano");   
            }
            catch (Exception ec)
            {
                Console.WriteLine("Doslo je do greske prilikom pristupanja bazi podataka: " + ec.Message);
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
