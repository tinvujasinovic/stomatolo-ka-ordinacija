namespace Model
{
    public class Duration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }

        public Duration(int id, string name, int duration)
        {
            Id = id;
            Name = name;
            DurationInMinutes = duration;
        }
    }
}
