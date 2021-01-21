using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GAMe.Pages
{
    public class OdjavaModel : PageModel
    {
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                SessionClass.UsernameKorisnika = null;
                SessionClass.TipKorisnika = null;
                SessionClass.ImeKorisnika = null;
                return RedirectToPage("./Index");
            }
        }
    }
}
