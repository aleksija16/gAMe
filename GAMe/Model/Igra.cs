using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMe.Model
{
    public class Igra
    {
        public int idIgra{ get; set; }
        public string naziv { get; set; }
        public string zanr { get; set; }
        public string verzija { get; set; }
        public string opis { get; set; }
        public string cena { get; set; }
    }
}
