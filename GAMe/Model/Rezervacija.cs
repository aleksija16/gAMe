using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMe.Model
{
    public class Rezervacija
    {
        public int idRezervacija { get; set; }
        public string korisnikUsername { get; set; }
        public int igraId { get; set; }
        public DateTime datum { get; set; }
        public string trajanje { get; set; }
    }
}
