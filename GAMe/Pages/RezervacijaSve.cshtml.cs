using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using GAMe.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GAMe.Pages
{
    public class RezervacijaSveModel : PageModel
    {
        [BindProperty]
        public IList<Rezervacija> SveRezervacije { get; set; }
        public void OnGet()
        {
            ISession session = SessionManager.GetSession();
            SveRezervacije = new List<Rezervacija>();

            var sveRezervacije = session.Execute("select * from Rezervacija");

            foreach (var rezervacijaSve in sveRezervacije)
            {
                Rezervacija rezervacija = new Rezervacija();
                rezervacija.idRezervacija = (int)rezervacijaSve["idrezevacija"];
                rezervacija.korisnikUsername = rezervacijaSve["korisnikusername"].ToString();
                rezervacija.igraId = (int)rezervacijaSve["igraId"];
                rezervacija.datum = (DateTime)rezervacijaSve["datum"];
                rezervacija.trajanje =rezervacijaSve["trajanje"].ToString();

                SveRezervacije.Add(rezervacija);
            }

        }
    }
}
