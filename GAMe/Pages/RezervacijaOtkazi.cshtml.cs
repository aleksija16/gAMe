using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GAMe.Pages
{
    public class RezervacijaOtkaziModel : PageModel
    {

        public IActionResult OnPost(int id)
        {
            ISession sess = SessionManager.session;

            RowSet reservationData = sess.Execute("delete from Rezervacija where idRezervacija = " + id + "");

            return RedirectToPage("./IgraSve");
        }

    }
}
