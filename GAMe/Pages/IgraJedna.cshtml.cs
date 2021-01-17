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
    public class IgraJednaModel : PageModel
    {
        [BindProperty]
        public Igra TrenutnaIgra { get; set; }


        public IActionResult OnGet(int id)
        {
            ISession session = SessionManager.GetSession();
            TrenutnaIgra = new Igra();

            if (session == null)
                return null;

            Row igraJedna = session.Execute("select * from Igra where \"idigra\"  = " + id + "").FirstOrDefault();

            if (igraJedna != null)
            {
                TrenutnaIgra.naziv = igraJedna["naziv"] != null ? igraJedna["naziv"].ToString() : string.Empty;
                TrenutnaIgra.zanr = igraJedna["zanr"] != null ? igraJedna["zanr"].ToString() : string.Empty;
                TrenutnaIgra.verzija = igraJedna["verzija"] != null ? igraJedna["verzija"].ToString() : string.Empty;
                TrenutnaIgra.opis = igraJedna["opis"] != null ? igraJedna["opis"].ToString() : string.Empty;
                TrenutnaIgra.cena = igraJedna["cena"] != null ? igraJedna["cena"].ToString() : string.Empty;
            }

            return Page();
        }
    }
}
