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
    public class PrijavaModel : PageModel
    {
        [BindProperty]
        public Korisnik TrenutniKorisnik { get; set; }
        public Korisnik PostojiKorisnik { get; set; }
        public int SessionId { get; set; }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                ISession session = SessionManager.GetSession();
                PostojiKorisnik = new Korisnik();


                Row postojiKorisnik = session.Execute("select * from Korisnik where username='" + TrenutniKorisnik.username + "'").FirstOrDefault();

                if (postojiKorisnik != null)
                {

                    PostojiKorisnik.ime = postojiKorisnik["ime"] != null ? postojiKorisnik["ime"].ToString() : string.Empty;
                    PostojiKorisnik.prezime = postojiKorisnik["prezime"] != null ? postojiKorisnik["prezime"].ToString() : string.Empty;
                    PostojiKorisnik.username = postojiKorisnik["username"].ToString();
                    PostojiKorisnik.password = postojiKorisnik["password"].ToString();
                    PostojiKorisnik.telefon = postojiKorisnik["telefon"] != null ? postojiKorisnik["telefon"].ToString() : string.Empty;
                    PostojiKorisnik.tipKorisnika = postojiKorisnik["tipkorisnika"].ToString();

                    SessionClass.TipKorisnika = PostojiKorisnik.tipKorisnika;
                    SessionClass.UsernameKorisnika = PostojiKorisnik.username;
                    if (PostojiKorisnik.tipKorisnika == "K")
                    {
                        SessionClass.ImeKorisnika = PostojiKorisnik.ime + " " + PostojiKorisnik.prezime;
                    }
                    else if (PostojiKorisnik.tipKorisnika == "A")
                    {
                        SessionClass.ImeKorisnika = "Administrator";
                    }
                    return RedirectToPage("./Index");
                }
                else
                {
                    SessionId = -1;
                    return Page();
                }

            }
        }
    }
}
