using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KupciRepository
    {
        public string ConnectionKupci = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Projekti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Kupci> SviKupci()   //Vraca listu kupaca
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Kupci";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Kupci> lista = new List<Kupci>();
                while (sqlDataReader.Read())
                {
                    Kupci k = new Kupci();
                    k.Sifra = sqlDataReader.GetInt32(0);
                    k.Naziv = sqlDataReader.GetString(1);
                    k.Adresa = sqlDataReader.GetString(2);
                    k.Pib = sqlDataReader.GetInt32(3);
                    k.Kontakt = sqlDataReader.GetInt32(4);

                    lista.Add(k);
                }
                return lista;
            }

        }


        public int NoviKupac(Kupci k)           //Unosi novog kupca u bazu podataka
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Kupci VALUES(" + string.Format(
                    "'{0}','{1}',{2},{3}", k.Naziv, k.Adresa, k.Pib, k.Kontakt) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }


        public int PromeniKupca(Kupci k)                    //Menja podatke kupca
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Kupci SET Naziv = '" + k.Naziv +
                    "', Adresa = '" + k.Adresa + "', pib = " + k.Pib +
                    ", Kontakt = '" + k.Kontakt + "' WHERE Sifra = " + k.Sifra;

                return sqlCommand.ExecuteNonQuery();
            }
        }











    }
}
