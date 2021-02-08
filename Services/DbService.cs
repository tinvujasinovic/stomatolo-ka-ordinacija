using Model;
using Services.Zahvati;
using Services.Trajanja;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System;
using Services.RadnoVrijeme;

namespace Services
{
    public class DbService : IZahvatService, ITrajanjeServiceService, IRadnoVrijemeService
    {
        private static DbService instance = new DbService();
        private SqlConnection connection { get; set; }

        private DbService()
        {
            connection = new SqlConnection("Data Source=TIN\\SQLEXPRESS;Integrated Security=True; Database=StomatoloskaOrdinacija;");
        }

        public static DbService GetInstance()
        {
            return instance;
        }

        #region Zahvat

        public bool SaveZahvat(Zahvat model)
        {
            try
            {
                if(model.Id > 0)
                {

                    connection.Open();
                    var cmd = ExecuteQuery($"UPDATE dbo.Zahvat SET Naziv = '{model.Naziv}', Sifra = '{model.Šifra}', Cijena = '{model.Cijena.ToString().Replace(',', '.')}', TrajanjeId = {model.Trajanje.Id} WHERE Id = {model.Id}");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                else
                {
                    connection.Open();
                    var cmd = ExecuteQuery($"INSERT INTO dbo.Zahvat ([Sifra], [Naziv], [Cijena], [TrajanjeId]) VALUES ('{model.Šifra}', '{model.Naziv}', '{model.Cijena.ToString().Replace(',', '.')}', {model.Trajanje.Id})");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }

            }
            catch(Exception e)
            {
                connection.Close();
                return false;
            }
        }

        public Zahvat GetZahvat(int id)
        {
            try {
                var zahvat = new Zahvat();
                connection.Open();

                var cmd = ExecuteQuery($@"SELECT * FROM [dbo].Zahvat WHERE Active = 1 AND Id = {id}");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    zahvat = new Zahvat((int)reader.GetValue(0), (string)reader.GetValue(2), (string)reader.GetValue(3), (decimal)reader.GetValue(4), new Trajanje((int)reader.GetValue(5)));
                }
                reader.Close();

                cmd = ExecuteQuery($@"SELECT * FROM [dbo].Trajanje WHERE Id = {zahvat.Trajanje.Id}");

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    zahvat.Trajanje.Naziv = (string)reader.GetValue(2);
                    zahvat.Trajanje.TrajanjeUMin = (int)reader.GetValue(3);
                }
                reader.Close();

                connection.Close();
                return zahvat;
            }
            catch(Exception e)
            {
                connection.Close();
                return null;
            }   
        }

        public List<Zahvat> GetAllZahvat()
        {
            try
            {
                var lista = new List<Zahvat>();
                connection.Open();

                var cmd = ExecuteQuery($@"SELECT * FROM [dbo].Zahvat WHERE Active = 1");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Zahvat((int)reader.GetValue(0), (string)reader.GetValue(2), (string)reader.GetValue(3), (decimal)reader.GetValue(4), new Trajanje((int)reader.GetValue(5))));
                }
                reader.Close();

                foreach (var item in lista)
                {

                    cmd = ExecuteQuery($@"SELECT * FROM [dbo].Trajanje WHERE Id = {item.Trajanje.Id}");

                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        item.Trajanje.Naziv = (string)reader.GetValue(2);
                        item.Trajanje.TrajanjeUMin = (int)reader.GetValue(3);
                    }
                    reader.Close();
                }

                connection.Close();
                return lista;
            }
            catch(Exception e)
            {
                connection.Close();
                return null;
            }
         
        }

        public bool DeleteZahvat(int id)
        {
            try
            {
                connection.Open();
                var cmd = ExecuteQuery($"UPDATE [dbo].Zahvat SET Active = 0 WHERE Id = {id}");
                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch(Exception e)
            {
                connection.Close();
                return false;
            }
        }

        #endregion

        #region Trajanje

        public List<Trajanje> GetAllTrajanja()
        {
            try
            {
                var lista = new List<Trajanje>();
                connection.Open();

                var cmd = ExecuteQuery($@"SELECT * FROM [dbo].Trajanje");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Trajanje((int)reader.GetValue(0), (string)reader.GetValue(2), (int)reader.GetValue(3)));
                }

                connection.Close();
                return lista;
            }
            catch(Exception e)
            {
                connection.Close();
                return null;
            }
          
        }

        #endregion

        #region Radno vrijeme

        public Model.RadnoVrijeme GetRadnoVrijeme()
        {
            try
            {
                var radno = new Model.RadnoVrijeme();
                connection.Open();
                    
                var cmd = ExecuteQuery($@"SELECT * FROM dbo.RadnoVrijeme WHERE Id = 1");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    radno = new Model.RadnoVrijeme((DateTime)reader.GetValue(1), (DateTime)reader.GetValue(2));
                    
                    reader.Close();
                    connection.Close();
                    return radno;
                }

                reader.Close();
                connection.Close();

                return null;
            }
            catch (Exception e)
            {
                connection.Close();
                return null;
            }
        }

        public bool SaveRadnoVrijeme(Model.RadnoVrijeme model)
        {
            try
            {
                connection.Open();
                var cmd = ExecuteQuery($"UPDATE dbo.RadnoVrijeme SET Pocetak = '{FormatDate(model.Pocetak)}', Kraj = '{FormatDate(model.Kraj)}' WHERE Id = 1");

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                return false;
            }
        }

        #endregion

        private SqlCommand ExecuteQuery(string cmd)
        {
            return new SqlCommand(cmd, connection);
        }

        private string FormatDate(DateTime date)
        {
            string dateString = $"{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}.{date.Millisecond}";

            return dateString;
        }

    }
}
