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
    public class RezervacijaJednaModel : PageModel
    {
        [BindProperty]
        public Rezervacija TrenutnaRezervacija { get; set; }
        [BindProperty]
        public Igra TrenutnaIgra { get; set; }


        public IActionResult OnGet(int id)
        {
            ISession sess = SessionManager.session;
            TrenutnaRezervacija = new Rezervacija();
            TrenutnaIgra = new Igra();

            Row rezervacijaJedna = sess.Execute("select * from Rezervacija where idrezervacija  = " + id + "").FirstOrDefault();
            Row igraJedna = sess.Execute("select * from Igra where idigra  = " + (int)rezervacijaJedna["igra"] + "").FirstOrDefault();
            if (rezervacijaJedna != null)
            {
                TrenutnaRezervacija.idRezervacija =id;
                TrenutnaRezervacija.datum = rezervacijaJedna["datum"].ToString();
                TrenutnaRezervacija.trajanje = rezervacijaJedna["trajanje"].ToString();

            }
            if (igraJedna != null)
            {
                TrenutnaIgra.idIgra = (int)rezervacijaJedna["igra"];
                TrenutnaIgra.naziv = igraJedna["naziv"].ToString();
            }
            return Page();
        }
    }
}
