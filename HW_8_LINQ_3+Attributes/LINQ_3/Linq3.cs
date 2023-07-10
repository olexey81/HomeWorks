namespace HW_8_LINQ_3_Menu
{
    public static class Linq3
    {
        static List<Film> films = new List<Film>()
        {
            new Film { Name = "The Silence of the Lambs", Director ="Jonathan Demme" },
            new Film { Name = "The World's Fastest Indian", Director ="Roger Donaldson" },
            new Film { Name = "The Recruit", Director ="Roger Donaldson" }
        };

        static List<Director> directors = new List<Director>()
        {
            new Director {Name="Jonathan Demme", Country="USA"},
            new Director {Name="Roger Donaldson", Country="New Zealand"},
        };

        public static void ShowLinqExamples()
        {
            //        Завдання:

            //  1. string.Join за допомогою Aggregate
            Console.WriteLine(string.Join(", ", films.Select(f => f.Name)));                    // string.Join
            Console.WriteLine(films.Select(f => f.Name).Aggregate((x, y) => x + ", " + y) +
                "\n" + new string('-', 60));                                                    // те саме через Aggregate

            //  2. string.Concat за допомогою Aggregate
            Console.WriteLine(string.Concat(films.Select(f => f.Director)));                    // string.Concat
            Console.WriteLine(films.Select(f => f.Director).Aggregate((x, y) => x + y) +
                "\n" + new string('-', 60));                                                    // те саме через Aggregate

            //  3. Вивести всі фільми у такому форматі: "FilmName DirectorName (DirectorCountry)"
            Console.WriteLine(
                films.Select(f => $"{f.Name} {f.Director} ({directors.First(d => d.Name == f.Director).Country})").
                Aggregate((x, y) => x + "\n" + y) +
                "\n" + new string('-', 60));
                

            //  4. Виведіть усі фільми кожного режисера через кому
            Console.WriteLine(
                directors.Select(d => $"{d.Name}: {films.Where(f => f.Director == d.Name).Select(f => f.Name).Aggregate((x, y) => x + ", " + y)}").
                Aggregate((x, y) => x + "\n" + y) +
                "\n" + new string('-', 60));
        }
    }
}

