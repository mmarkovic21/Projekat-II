using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ArtikliRepository
    {

        public string ConnectionKupci = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Projekti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";





        public List<Artikli> SviArtikli()                                                //Vraca listu svih artikala iz baze podataka
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "select * from Artikli";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Artikli> listaArtikala = new List<Artikli>();
                while (sqlDataReader.Read())
                {
                    Artikli a = new Artikli();
                    a.SifraArtikla = sqlDataReader.GetInt32(0);
                    a.Naziv = sqlDataReader.GetString(1);
                    a.Cena = sqlDataReader.GetInt32(2);
                    a.Kolicina = sqlDataReader.GetInt32(3);


                    listaArtikala.Add(a);
                }
                return listaArtikala;
            }
        }


        public int NoviArtikal(Artikli a)                                                  //Unosi novi artikal
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Artikli (NazivArtikla, Cena, Kolicina)   VALUES(" + string.Format(
                    "'{0}',{1},{2}", a.Naziv, a.Cena, a.Kolicina) + ")";

                return sqlCommand.ExecuteNonQuery();
            }
        }


        public int PromeniArtikal(Artikli a)                                            //Promeni Artikal
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Artikli SET NazivArtikla = '" + a.Naziv +
                    "', Cena = '" + a.Cena + "', Kolicina = " + a.Kolicina +
                     " WHERE SifraArtikla = " + a.SifraArtikla;

                return sqlCommand.ExecuteNonQuery();
            }
        }



        public int PromeniKolicinuArtikla(int SifraArtikla, int dodato)                     //Menja kolicinu artikla
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;


                sqlCommand.CommandText = "UPDATE Artikli SET Kolicina = " + dodato +
                    " WHERE SifraArtikla = " + SifraArtikla;

                return sqlCommand.ExecuteNonQuery();

            }
        }

        public int ObrisiArtikal(Artikli a)                                             //Brise artikal
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionKupci))
            {

                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;


                sqlCommand.CommandText = "DELETE FROM ARTIKLI WHERE SifraArtikla = " + a.SifraArtikla;

                return sqlCommand.ExecuteNonQuery();

            }
        }
    }
}
