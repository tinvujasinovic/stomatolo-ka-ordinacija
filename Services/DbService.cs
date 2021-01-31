using Model;
using Services.Zahvati;
using Services.Trajanja;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Services
{
    public class DbService : IZahvatService, ITrajanjeService
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

        public void SaveZahvat(Zahvat model)
        {
            connection.Open();
            var cmd = new SqlCommand($@"INSERT INTO dbo.Zahvat VALUES 
                {model.Šifra},
                {model.Naziv},
                {model.Cijena},
                {model.Trajanje.Id}");

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public Zahvat GetZahvat(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Zahvat> GetAllZahvat()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteZahvat(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Trajanje> GetAllTrajanja()
        {
            var lista = new List<Trajanje>();
            connection.Open();
            var cmd = new SqlCommand($@"SELECT * FROM [dbo].Trajanje", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Trajanje((int)reader.GetValue(0), (string)reader.GetValue(1), (int)reader.GetValue(2)));
            }

            connection.Close();
            return null;
        }
    }
}
