namespace HomeWork_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FilmManager filmManager = new FilmManager();
            filmManager.AddFilm(new Film {Name = "Кровавый спорт", Year = 1986, Regisseur = "Вася", Genre = "Боевик" });
            filmManager.AddFilm(new Film { Name = "Однажды в Вегасе", Year = 2007, Regisseur = "Петя", Genre = "Комедия" });
            filmManager.SaveToJson("Films.json");
            filmManager.LoadFromJson("Films.json");
            Console.WriteLine("\nВыгрузка из json\n");
            foreach (var i in filmManager.films)
            {
                Console.WriteLine($"Name: {i.Name}, Year: {i.Year}, Regisseur: {i.Regisseur}, Genre: {i.Genre}");
            }
            filmManager.SaveToXML("Produts.xml");
            filmManager.LoadFromXML("Produts.xml");
            Console.WriteLine("\nВыгрузка из xml\n");
            foreach (var i in filmManager.films)
            {
                Console.WriteLine($"Name: {i.Name}, Year: {i.Year}, Regisseur: {i.Regisseur}, Genre: {i.Genre}");
            }
            IEnumerable<Film> sortedFilms = filmManager.FiltrFilmByGenre("Комедия");
            Console.WriteLine("\nВыборка жанра комедия\n");
            foreach (var i in sortedFilms)
            {
                Console.WriteLine($"Name: {i.Name}, Year: {i.Year}, Regisseur: {i.Regisseur}, Genre: {i.Genre}");
            }
        }
    }
}
