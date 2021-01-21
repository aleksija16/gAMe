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
        public async Task OnGetAsync()
        {
            ISession session = await SessionManager.GetSessionAsync();
            SveRezervacije = new List<Rezervacija>();

            var sveRezervacije = session.Execute("select * from Rezervacija");

            foreach (var rezervacijaSve in sveRezervacije)
            {
                Rezervacija rezervacija = new Rezervacija();
                rezervacija.idRezervacija = (int)rezervacijaSve["idrezervacija"];
                rezervacija.korisnik = rezervacijaSve["korisnik"].ToString();
                rezervacija.igra = (int)rezervacijaSve["igra"];
                rezervacija.datum = rezervacijaSve["datum"].ToString();
                rezervacija.trajanje =rezervacijaSve["trajanje"].ToString();

                SveRezervacije.Add(rezervacija);
            }

        }
    }
}
