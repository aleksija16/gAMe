using Cassandra.Data.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMe.Model
{
    public class Korisnik
    {
        public string username { get; set; }
        public string password { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }
        public string tipKorisnika { get; set; }
    }
}
