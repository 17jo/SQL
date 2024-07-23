using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.ManagedDataAccess.Client;
namespace faza_7
{
    class zadatak3
    {
        static void Main(string[] args)
        {
            OracleConnection con = null;
            string conString = "Data Source = 160.99.12.92/GISLAB_PD; User Id = XXX; Password = XXX;";
            try
            {
                Console.WriteLine("Uneti ime pa prezime zaposlenog kojem zelite da azurirate broj telefona :");
                string ime = Console.ReadLine();
                string prezime = Console.ReadLine();
                Console.WriteLine("Uneti broj telefona : ");
                int  broj = Int32.Parse(Console.ReadLine());
                int pom = broj, i = 0 ;
                while(pom>0)
                {
                    pom = pom / 10;
                    i++;
                }
                if (i<10)
                {
                    con = new OracleConnection(conString);
                    con.Open();
                    StringBuilder strSQL = new StringBuilder();
                    strSQL.Append("UPDATE BROJ_TEL_ZAPOSLENOG ");
                    strSQL.Append(" SET BROJ_TEL = :broj ");
                    strSQL.Append(" WHERE LK_ZAPOSLENI=(SELECT LK_ZAPOSLENI FROM BROJ_TEL_ZAPOSLENOG INNER JOIN ");
                    strSQL.Append(" ZAPOSLENI ON ZAPOSLENI.BROJ_LK=BROJ_TEL_ZAPOSLENOG.LK_ZAPOSLENI WHERE ");
                    strSQL.Append(" ZAPOSLENI.IME= :ime AND ZAPOSLENI.PREZIME= :prezime) ");
                    OracleCommand cmd = new OracleCommand(strSQL.ToString(), con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    OracleParameter parBroj = new OracleParameter("broj", OracleDbType.Int32);
                    OracleParameter parIme = new OracleParameter("ime", OracleDbType.Char);
                    OracleParameter parPrezime = new OracleParameter("prezime", OracleDbType.Char);
                    parBroj.Value = broj;
                    parIme.Value = ime;
                    parPrezime.Value = prezime;
                    cmd.Parameters.Add(parBroj);
                    cmd.Parameters.Add(parIme);
                    cmd.Parameters.Add(parPrezime);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Azurirano");
                }
                else
                    Console.WriteLine("Uneli ste nedozvoljeni broj cifara za broj telefona, dozvoljeni broj je 10");
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
