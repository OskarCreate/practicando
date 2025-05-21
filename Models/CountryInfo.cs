namespace practicando.Models
{
    public class CountryInfo
    {
        public Name? name { get; set; }
        public Flags? flags { get; set; }
        public string? region { get; set; }
    }

    public class Name
    {
        public string? official { get; set; }
    }

    public class Flags
    {
        public string? png { get; set; }
    }
}
