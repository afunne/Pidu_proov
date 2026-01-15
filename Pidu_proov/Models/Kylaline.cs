using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pidu_proov.Models
{
    public class Kylaline
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public string Email { get; set; }
        public bool OnKutse { get; set; }
        //Välisvõti pühade tabelisse
        public int PyhaId { get; set; }
        //Navigeerimisomadus kylaline.pyha.Nimetus
        public virtual Pyha Pyha { get; set; }
    }
}