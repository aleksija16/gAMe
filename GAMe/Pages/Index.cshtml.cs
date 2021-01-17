using Cassandra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAMe.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet guestData = session.Execute("insert into Igra(idIgra, naziv, zanr,verzija, opis, cena) values (1, 'Counter Strike', 'Arkadne', '1.0','Ovo je igra', '5000din')");

        }
    }
}
