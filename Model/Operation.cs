namespace Model
{
    public class Operation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Duration Duration { get; set; }

        public Operation(int id, string code, string name, decimal price, Duration duration)
        {
            Id = id;
            Code = code;
            Name = name;
            Price = price;
            Duration = duration;
        }

        public Operation(int id, string code, string name, Duration duration)
        {
            Id = id;
            Name = name;
            Code = code;
            Duration = duration;
        }

        public Operation()
        {

        }

    }
}
