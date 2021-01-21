using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMe.Model
{
    public class Rezervacija
    {
        public int idRezervacija { get; set; }
        public string korisnik { get; set; }
        public int igra { get; set; }
        public string datum { get; set; }
        public string trajanje { get; set; }
    }
}
