using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hognogi_Daniela_Taisia_Laborator2.Data;
using Hognogi_Daniela_Taisia_Laborator2.Models;

namespace Hognogi_Daniela_Taisia_Laborator2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context _context;

        public IndexModel(Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publisher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
