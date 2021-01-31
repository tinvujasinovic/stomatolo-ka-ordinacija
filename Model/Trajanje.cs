namespace Model
{
    public class Trajanje
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int TrajanjeUMin { get; set; }

        public Trajanje(int id, string naziv, int trajanje)
        {
            Id = id;
            Naziv = naziv;
            TrajanjeUMin = trajanje;
        }

        public Trajanje(int id)
        {
            Id = id;
        }
    }
}
