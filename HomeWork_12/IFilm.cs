using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_12
{
    public interface IFilm
    {
        string Name { get; set; }
        int Year { get; set; }
        string Regisseur { get; set; }
        string Genre { get; set; }
    }
}
