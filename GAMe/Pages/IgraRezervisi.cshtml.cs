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
    public class IgraRezervisiModel : PageModel
    {

        [BindProperty]
        public Igra OvaIgra { get; set; }
        [BindProperty]
        public Rezervacija RezervacijaIgre { get; set; }
        [BindProperty]
        public string DanasnjiDatum { get; set; }

        public IActionResult OnGet(int id)
        {

            ISession sess = SessionManager.session;

            Row igra = sess.Execute("select * from Igra where \"idigra\"  = " + id + "").FirstOrDefault();


            String month = DateTime.Now.Month.ToString();
            if (DateTime.Now.Month < 10)
            {
                month = month.Insert(0, "0");
            }
            String day = DateTime.Now.Day.ToString();
            if (DateTime.Now.Day < 10)
            {
                day = day.Insert(0, "0");
            }
            DanasnjiDatum = DateTime.Now.Year.ToString() + "-" + month + "-" + day;

            if (igra == null)
            {
                return NotFound();
            }

            return this.Page();
        }
        public IActionResult OnPost(int id)
        {
            if (RezervacijaIgre == null)
            {
                return this.Page();
            }

            ISession sess = SessionManager.session;

            Row nextId = sess.Execute("select * from Id where naziv='rezervacija'").FirstOrDefault();
            int stariId = (int)nextId["next"];
            RowSet igraNova = sess.Execute("insert into Rezervacija (idrezervacija, korisnik,igra,datum,trajanje) values (" + stariId + ",'" + SessionClass.UsernameKorisnika + "'," + id + ",'" + RezervacijaIgre.datum.ToString() + "','" + RezervacijaIgre.trajanje + "')");
            int noviId = stariId + 1;
            sess.Execute("update Id SET next = " + noviId + " WHERE naziv = 'rezervacija' ");

            return RedirectToPage("./RezervacijaJedna", new { id = stariId, });

        }


    }
}
