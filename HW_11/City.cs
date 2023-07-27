namespace HW_11_Generator
{
    public record class City 
    {
        public List<string> Name { get; set; }
        public List<string> Country { get; set; }
        public List<string> Region { get; set; }
        public List<int> Population { get; set; }
        public List<float> Area { get; set; }

        public int Count { get; set; }

        public City()
        {
            Name = new List<string>();
            Country = new List<string>();
            Region = new List<string>();
            Population = new List<int>();
            Area = new List<float>();
            Count = 0;
        }

        //public override bool Equals(object? obj)
        //{
        //    if (obj == null || obj is not City other)
        //        return false;

        //    return Name.SequenceEqual(other.Name) &&
        //           Country.SequenceEqual(other.Country) &&
        //           Region.SequenceEqual(other.Region) &&
        //           Population.SequenceEqual(other.Population) &&
        //           Area.SequenceEqual(other.Area) &&
        //           Count == other.Count;
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(Name, Area, Population, Country, Population, Count);
        //}
    }
}
