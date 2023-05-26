using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KupovinaRepository
    {
        public string ConnectionKupci = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Projekti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Kupovina> SveKupovine()             // vraca listu svih kupovina
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Kupovine";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Kupovina> listaKupovine = new List<Kupovina>();

                while (sqlDataReader.Read())
                {


                    Kupovina k = new Kupovina();
                    k.SifraRacuna = sqlDataReader.GetInt32(1);
                    k.SifraKupca = sqlDataReader.GetInt32(2);
                   k.NazivKupca = sqlDataReader.GetString(3);
                    k.SifraArtikla = sqlDataReader.GetInt32(4);
                    k.NazivArtikla = sqlDataReader.GetString(5);
                    k.KolicinaArtikla = sqlDataReader.GetInt32(6);
                    k.CenaArtikla = sqlDataReader.GetInt32(7);
                    k.Datum1 = sqlDataReader.GetString(8);


                    listaKupovine.Add(k);
                }
                return listaKupovine;

            }
        }

        public int BrisanjeKupovine(int na, int ku, int ar)                 // Brisanje kupovine 
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Arikli WHERE SifraNarudzbenice = " + na + "and SifraKupca =" + ku + "and SifraArtikla = " + ar;

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int VratiSifru(Boolean first)            //U slucaju da je sifra 0 da je stavi na 1, a ako je veca od 0 da je samo uzme i postavi za sifru racuna
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();
                int sifraRacuna;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT TOP 1 SifraRacuna FROM Kupovine ORDER BY SifraRacuna DESC";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read() == false)
                {
                    sifraRacuna = 1;
                }
                else if (first)
                {
                    sifraRacuna = sqlDataReader.GetInt32(0) + 1;
                }
                else
                {
                    sifraRacuna = sqlDataReader.GetInt32(0);
                }
                return sifraRacuna;
            }
        }
        public int DodavanjeKupovine(Kupovina k, int sifraRacuna)       //Dodaje novu kupovinu u bazu podataka
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;

                sqlCommand.CommandText = "INSERT INTO Kupovine VALUES(" + string.Format(
                   "{0}, {1} , '{2}', {3}, '{4}', {5}, {6}, '{7}'", sifraRacuna, k.SifraKupca, k.NazivKupca, k.SifraArtikla, k.NazivArtikla, k.KolicinaArtikla, k.CenaArtikla, k.Datum1) + ")";


                return sqlCommand.ExecuteNonQuery();
            }
        }

        public List<Kupovina> PretragaKupovine(int sifra)               //Pretrazuje kupovine po sifri racuna
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Kupovine where SifraRacuna =" + sifra;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Kupovina> lista = new List<Kupovina>();

                while (sqlDataReader.Read())
                {


                    Kupovina k = new Kupovina();
                    k.SifraRacuna = sqlDataReader.GetInt32(1);
                    k.SifraKupca = sqlDataReader.GetInt32(2);
                    k.NazivKupca = sqlDataReader.GetString(3);
                    k.SifraArtikla = sqlDataReader.GetInt32(4);
                    k.NazivArtikla = sqlDataReader.GetString(5);
                    k.KolicinaArtikla = sqlDataReader.GetInt32(6);
                    k.CenaArtikla = sqlDataReader.GetInt32(7);
                    k.Datum1 = sqlDataReader.GetString(8);


                    lista.Add(k);
                }
                return lista;


            }

        }

    }
}
