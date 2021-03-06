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
    public class IgraDodajModel : PageModel
    {

        [BindProperty]
        public Igra NovaIgra { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {

                ISession sess = SessionManager.session;

                Row nextId = sess.Execute("select * from Id where naziv='igra'").FirstOrDefault();
                int id = (int)nextId["next"];
                RowSet igraNova = sess.Execute("insert into Igra (idigra, naziv,zanr, verzija,opis,cena,slika) values (" + id + ",'" + NovaIgra.naziv + "','" + NovaIgra.zanr + "','" + NovaIgra.verzija + "','" + NovaIgra.opis + "','" + NovaIgra.cena + "','" + NovaIgra.slika + "')");
                id++;
                sess.Execute("update Id SET next = " + id + " WHERE naziv = 'igra' ");

                return RedirectToPage("./IgraSve");
            }
        }
    }
}
