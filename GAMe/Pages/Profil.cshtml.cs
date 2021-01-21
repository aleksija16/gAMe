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
    public class ProfilModel : PageModel
    {
       [BindProperty]
       public IList<Rezervacija> SveRezervacije { get; set; }
       [BindProperty]
       public Korisnik Korisnik { get; set; }
      
        public void OnGet()
        {
            ISession ses = SessionManager.session;
            Korisnik = new Korisnik();
            Row postojiKorisnik = ses.Execute("select * from Korisnik where username='" + SessionClass.UsernameKorisnika + "'").FirstOrDefault();

            Korisnik.ime = postojiKorisnik["ime"].ToString();
            Korisnik.prezime = postojiKorisnik["prezime"] != null ? postojiKorisnik["prezime"].ToString() : string.Empty;
            Korisnik.username = postojiKorisnik["username"].ToString();
            Korisnik.password = postojiKorisnik["password"].ToString();
            Korisnik.telefon = postojiKorisnik["telefon"] != null ? postojiKorisnik["telefon"].ToString() : string.Empty;

          
            SveRezervacije = new List<Rezervacija>();
            var sveRezervacije = ses.Execute("select * from Rezervacija");

            foreach (var rezervacijaSve in sveRezervacije)
            {
                if (rezervacijaSve["korisnik"].ToString() == SessionClass.UsernameKorisnika)
                {
                    Rezervacija rezervacija = new Rezervacija();
                    rezervacija.idRezervacija = (int)rezervacijaSve["idrezervacija"];
                    rezervacija.korisnik = rezervacijaSve["korisnik"].ToString();
                    rezervacija.igra = (int)rezervacijaSve["igra"];
                    rezervacija.datum = rezervacijaSve["datum"].ToString();
                    rezervacija.trajanje = rezervacijaSve["trajanje"].ToString();
                    SveRezervacije.Add(rezervacija);
                }
            }


        }
    }
}
