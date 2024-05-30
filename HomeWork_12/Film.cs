using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_12
{
    public class Film:IFilm
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Regisseur { get; set; }
        public string Genre { get; set; }
    }
}
