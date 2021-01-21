using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cassandra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GAMe.Pages
{
    public class IgraObrisiModel : PageModel
    {

        public async Task<IActionResult> OnPostAsync(int id)
        {

            ISession session = await SessionManager.GetSessionAsync();

            RowSet reservationData = session.Execute("delete from Igra where idigra = " + id + "");

            return RedirectToPage("./IgraSve");
        }
       
    }
}
