namespace HW_7_LINQ_2
{
    class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }

        //public override string ToString()
        //{
        //    return $"{Name},  {Author}, {Actors}, {Length}"; 
        //}
    }
}