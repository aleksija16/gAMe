using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GAMe.Model;
using Cassandra;

namespace GAMe.Pages
{
    public class IgraSveModel : PageModel
    {
        [BindProperty]
        public IList<Igra> SveIgre { get; set; }
        public void OnGet()
        {

            ISession sess = SessionManager.session;

            SveIgre = new List<Igra>();

            var sveIgre = sess.Execute("select * from Igra");

            foreach (var igraSve in sveIgre)
            {
                Igra igra = new Igra();
                igra.idIgra = (int)igraSve["idigra"];
                igra.naziv = igraSve["naziv"].ToString();
                igra.zanr = igraSve["zanr"] != null ? igraSve["zanr"].ToString() : string.Empty;
                igra.verzija = igraSve["verzija"] != null ? igraSve["verzija"].ToString() : string.Empty;
                igra.opis = igraSve["opis"] != null ? igraSve["opis"].ToString() : string.Empty;
                igra.cena = igraSve["cena"] != null ? igraSve["cena"].ToString() : string.Empty;
                igra.slika = igraSve["slika"] != null ? igraSve["slika"].ToString() : string.Empty;

                SveIgre.Add(igra);
            }

        }
    }
}
