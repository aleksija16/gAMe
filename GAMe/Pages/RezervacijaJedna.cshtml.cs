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


        public async Task<IActionResult> OnGetAsync(int id)
        {
            ISession session = await SessionManager.GetSessionAsync();
            TrenutnaRezervacija = new Rezervacija();
            TrenutnaIgra = new Igra();
            if (session == null)
                return null;

            Row rezervacijaJedna = session.Execute("select * from Rezervacija where idrezervacija  = " + id + "").FirstOrDefault();
            Row igraJedna = session.Execute("select * from Igra where idigra  = " + (int)rezervacijaJedna["igra"] + "").FirstOrDefault();
            if (rezervacijaJedna != null)
            {
                TrenutnaIgra.naziv = igraJedna["naziv"].ToString();
                TrenutnaRezervacija.datum = rezervacijaJedna["datum"].ToString();
                TrenutnaRezervacija.trajanje = rezervacijaJedna["trajanje"].ToString();
                
            }
            if (igraJedna != null)
            {
                TrenutnaIgra.naziv = igraJedna["naziv"].ToString();
            }
                return Page();
        }
    }
}
