using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hognogi_Daniela_Taisia_Laborator2.Data;
using Hognogi_Daniela_Taisia_Laborator2.Models;

namespace Hognogi_Daniela_Taisia_Laborator2.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context _context;

        public DetailsModel(Hognogi_Daniela_Taisia_Laborator2.Data.Hognogi_Daniela_Taisia_Laborator2Context context)
        {
            _context = context;
        }

        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            else
            {
                Author = author;
            }
            return Page();
        }
    }
}
