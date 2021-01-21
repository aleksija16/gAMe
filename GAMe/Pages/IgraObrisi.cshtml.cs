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
    public class IgraObrisiModel : PageModel
    {
        public int provera = 0;
        [BindProperty]
        public IList<Rezervacija> SveRezervacije { get; set; }
        public IActionResult OnGet(int id)
        {
            ISession sess = SessionManager.session;

            SveRezervacije = new List<Rezervacija>();

            var sveRezervacije = sess.Execute("select * from Rezervacija");

            foreach (var rezervacijaSve in sveRezervacije)
            {
                if ((int)rezervacijaSve["igra"] == id)
                {
                    if (Convert.ToDateTime(@rezervacijaSve["datum"]) > DateTime.Now)
                    {
                        provera = 1;
                    }
                }
            }
            return Page();
        }


        public IActionResult OnPost(int id)
        {
            ISession sess = SessionManager.session;

            RowSet reservationData = sess.Execute("delete from Igra where idigra = " + id + "");

            return RedirectToPage("./IgraSve");
        }

    }
}
