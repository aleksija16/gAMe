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
    public class RegistracijaModel : PageModel
    {

        [BindProperty]
        public Korisnik NoviKorisnik { get; set; }
        [BindProperty]
        public bool PostojiVec { get; set; }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {

                ISession sess = SessionManager.session;


                Row postojiKorisnik = sess.Execute("select * from Korisnik where username='" + NoviKorisnik.username + "'").FirstOrDefault();

                if (postojiKorisnik != null)
                {
                    PostojiVec = true;
                    return this.Page();
                }

                RowSet reservationData = sess.Execute("insert into Korisnik (username, password,ime, prezime, telefon,tipkorisnika) values ('" + NoviKorisnik.username + "','" + NoviKorisnik.password + "','" + NoviKorisnik.ime + "','" + NoviKorisnik.prezime + "','" + NoviKorisnik.telefon + "', 'K')");


                return RedirectToPage("./Prijava");
            }
        }
    }
}
