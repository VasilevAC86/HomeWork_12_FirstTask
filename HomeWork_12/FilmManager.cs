using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace HomeWork_12
{
    public class FilmManager
    {
        public List<Film> films = new List<Film>();
        public void AddFilm(Film film) { films.Add(film); }
        public void RemoveFilm(string name) 
        {
            films.RemoveAll(f => f.Name == name); 
        }
        public void SaveToJson(string path) // Метод сохранения в файл json
        {
            string json = JsonConvert.SerializeObject(films);
            File.WriteAllText(path, json);
        }
        public void LoadFromJson(string path) // Возвращаем список продуктов, которые выпишем из нашего файла json
        {
            string json = File.ReadAllText(path);
            films = JsonConvert.DeserializeObject<List<Film>>(json);
        }
        public void SaveToXML(string path) // метод для сохранения в xml
        {            
            XElement xml = new XElement("Films",
                from f in films
                select new XElement("Film",                
                new XAttribute("Name", f.Name),
                new XAttribute("Year", f.Year),
                new XAttribute("Regisseur", f.Regisseur),
                new XAttribute("Genre", f.Genre)
                ));
            xml.Save(path);
        }
        public void LoadFromXML(string path)
        {
            var culture = System.Globalization.CultureInfo.InvariantCulture; // Чтобы при переводе double в string он воспринимал запятую как точку
            XDocument xml = XDocument.Load(path);
            films = xml.Descendants("Film")
                .Select(p => new Film
                {
                    Year = int.Parse(p.Attribute("Year").Value),
                    Name = p.Attribute("Name").Value,
                    Regisseur = p.Attribute("Regisseur").Value,
                    Genre = p.Attribute("Genre").Value
                }).ToList();
        }
        public IEnumerable<Film> FiltrFilmByGenre(string g)
        {
            return films.Where(p => p.Genre.ToLower() == g.ToLower());
        }
    }
}
