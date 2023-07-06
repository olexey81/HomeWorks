using HW_5_Collections;
using System.Linq;

namespace HW_7_LINQ_2
{
    internal class Program
    {
        static void Main()
        {
            var data = new MyList<object>()
            {
                "Hello",

                new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                new Book() { Author = "Terry Pratchett", Name = "Book  number  2", Pages = 110 },
                new Book() { Author = "Terry Pratchett", Name = "Book  number  3", Pages = 910 },

                new MyList<int>() {4, 6, 8, 2},

                new string[] {"Hello inside array"},

                new Film()
                {
                    Author = "Martin Scorsese", Name= "The Departed",
                    Actors = new MyList<Actor>()
                    {
                        new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22) },
                        new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11) },
                        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10) }
                    }
                },

                new Film()
                {
                    Author = "Gus Van Sant", Name = "Good Will Hunting",
                    Actors = new MyList<Actor>()
                    {
                        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                        new Actor() { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                    }
                },

                new Book() { Author = "Stephen King", Name="Finders Keepers", Pages = 200},
                new Book() { Author = "Stephen King", Name="Book  number  4", Pages = 400},

                "Leonardo DiCaprio"
            };

            // Завдання:

            //  1.Виведіть усі елементи, крім ArtObjects
            Console.WriteLine("All items except ArtObjects:\n" + 
                string.Join("\n", data.Where(item => item is not ArtObject).SelectMany(item => item is string[] array ? array : new[] { item })) +
                "\n" + new string('-', 60) );

            //  2. Виведіть імена всіх акторів
            Console.WriteLine("All actors:\n" + 
                string.Join("\n", data.OfType<Film>().SelectMany(film => film.Actors.Select(actor => actor.Name)).Distinct()) +
                "\n" + new string('-', 60));

            //  3. Виведіть кількість акторів, які народилися в серпні
            Console.WriteLine("Number of actors borned in August: " + 
                data.OfType<Film>().SelectMany(film => film.Actors).Where(actor => actor.Birthdate.Month == 8).Count() +
                "\n" + new string('-', 60));

            //  4. Виведіть два найстаріших імена акторів
            Console.WriteLine("Two oldest actors:\n" + 
                string.Join("\n", data.OfType<Film>().SelectMany(film => film.Actors).OrderBy(actor => actor.Birthdate).Take(2).Select(actor => actor.Name)) +
                "\n" + new string('-', 60));

            //5.Вивести кількість книг на авторів
            Console.WriteLine(string.Join("\n", data.OfType<Book>().GroupBy(book => book.Author).Select(group => $"Author {group.Key}: {group.Count()} books")) +
                "\n" + new string('-', 60));

            //  6. Виведіть кількість книг на одного автора та фільмів на одного режисера
            Console.WriteLine(string.Join("\n", data.OfType<Book>().GroupBy(book => book.Author).Select(group => $"Author {group.Key}: {group.Count()} books")) +
                "\n" + string.Join("\n", data.OfType<Film>().GroupBy(film => film.Author).Select(group => $"Author {group.Key}: {group.Count()} films")) +
                "\n" + new string('-', 60));

            //  7. Виведіть, скільки різних букв використано в іменах усіх акторів
            Console.WriteLine("There are " +
                data.OfType<Film>().SelectMany(film => film.Actors).SelectMany(actor => actor.Name.ToLower().Where(char.IsLetter)).Distinct().Count()
                + " different letters in actors names" + "\n" + new string('-', 60));

            //  8. Виведіть назви всіх книг, упорядковані за іменами авторів і кількістю сторінок
            Console.WriteLine(string.Join("\n", 
                data.OfType<Book>().OrderBy(book => book.Author).ThenBy(book => book.Pages)
                .Select(book => $"Book: {book.Name}, Author: {book.Author}, pages: {book.Pages}")) +
                "\n" + new string('-', 60));

            //  9. Виведіть ім'я актора та всі фільми за участю цього актора
            Console.WriteLine(string.Join("\n", data.OfType<Film>()
                .SelectMany(film => film.Actors.Select(actor => $"Actor: {actor.Name}, Films: {string.Join(", ", data.OfType<Film>()
                .Where(films => films.Actors.Any(actors => actors.Name == actor.Name)).Select(films => films.Name))}")).Distinct()) +
                "\n" + new string('-', 60));

            //  10. Виведіть суму загальної кількості сторінок у всіх книгах і всі значення int у всіх послідовностях у даних
            Console.WriteLine("Sum of all pages is: " + data.OfType<Book>().Sum(book => book.Pages) + "\n"
                + "Values of type \"Int\": " + string.Join(", ", data.SelectMany(item => item is IEnumerable<int> x ? x : Enumerable.Empty<int>())) + 
                "\n" + new string('-', 60));

            //  11. Отримати словник з ключем - автор книги, значенням - список авторських книг
            Console.WriteLine(string.Join("\n",
                data.OfType<Book>().GroupBy(book => book.Author).ToDictionary(group => group.Key, group => string.Join(", ", group.Select(book => book.Name)))
                .Select(dict => $"{dict.Key}: {dict.Value}")) +
                "\n" + new string('-', 60));

            ////  12. Вивести всі фільми "Метт Деймон", за винятком фільмів з акторами, імена яких представлені в даних у вигляді рядків
            Console.WriteLine(string.Join(", ", data.OfType<Film>()
                .Where(film => film.Actors.Any(actor => actor.Name == "Matt Damon") && !data.OfType<string>().Any(name => film.Actors.Any(actor => actor.Name == name)))
                .Select(film => film.Name)));
        }
    }
}